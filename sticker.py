import urllib, json
import sys, os, argparse, ConfigParser

parser = argparse.ArgumentParser(description='Get Stickers developed by Kurobyte');
parser.add_argument('-v', '--version', action='version', version='0.2');
parser.add_argument('-p', '--productVersion', dest='prodVer', action='store_true', help='Preforms the download of the last productVersion.meta');
parser.add_argument('-s', '--sticker_id', dest='sticker_id', action='store', help='Id of the sticker that you want to download');
parser.add_argument('-t', '--tabs', dest='tabs', action='store_true', help='Use -t when you want to download the tab_on/off.png and preview.png');
parser.add_argument('-i', '--ignore', dest='ignore', action='store_true', help='Ignore the local DB. Could fail the download.');
args = parser.parse_args();

config = ConfigParser.ConfigParser()
config.readfp(open('sticker.cfg'))

BASE_URL = 'http://dl.stickershop.line.naver.jp';
OUTPUT_DIR = config.get('user', 'outDir');

def main(sticker_id, tabs, ignore, version):
	ver = 1
	if not ignore:
		f = None;
		if os.path.isfile('./productVersions.meta'):
			f = open('./productVersions.meta');
		else :
			downloadProductVersion(version);
			f = open('./productVersions.meta');

		sticVer = json.loads(f.read());
		trobat = False;
		i = 0;

		while len(sticVer['versions']) > i and not trobat:
			if int(sticker_id) in sticVer['versions'][i]:
				ver = sticVer['versions'][i][1];
				trobat = True;

			i = i +1;

		if not trobat:
			print 'The id isn\'t in the local DB. If the download fails use the [-p] to fetch the newest DB(It could take a bit)';

	comp = getMeta(sticker_id, ver); 
	meta = comp[1];
	metaStr = comp[0];
	if meta != None:
		keys = list(meta['title'].keys())
		title = meta['title'][keys[0]];
		dirName = str(sticker_id)+' - '+replace_all(str(title));
		if not (os.path.exists(OUTPUT_DIR+dirName)):
			os.mkdir(OUTPUT_DIR+dirName);

		nStickers = len(meta['stickers']);
		print dirName;
		print str(nStickers)+' Stickers';
		for i in xrange(0, nStickers):
			png_id = meta['stickers'][i]['id'];
			downloadSticker(sticker_id, ver, png_id, dirName)
			print "[%3.2f%%]" % ((i * 100) / (nStickers -1))," Downloaded         \r",

		print "";
		if tabs:
			print "Downloading tabs";
			downloadExtra(sticker_id, ver, 'LINEStorePC', 'main', dirName, 0);
			downloadExtra(sticker_id, ver, 'android', 'tab_on', dirName, 0);
			downloadExtra(sticker_id, ver, 'android', 'tab_off', dirName, 0);
			downloadExtra(sticker_id, ver, 'LINEStorePC', 'preview', dirName, 0);

		print "Download complete";
		writeMeta(metaStr, dirName+'/productInfo.meta');

def getMeta(sticker_id, ver):
	meta = None;
	metaStr = None;
	try:
		url = urllib.urlopen(BASE_URL+'/products/0/0/'+str(ver)+'/'+str(sticker_id)+'/android/productInfo.meta');
		metaStr = url.read();
		meta = json.loads( metaStr );
	except Exception, e:
		print 'Not download. Check the id';
		print e;

	return [metaStr, meta];

def writeMeta(meta, metaFile):
	f = open(OUTPUT_DIR+metaFile, 'w');
	f.write(meta);
	f.close();

def downloadSticker(sticker_id, ver, png_id, dirName):
	try:
		urllib.urlretrieve(BASE_URL+'/products/0/0/'+str(ver)+'/'+str(sticker_id)+'/android/stickers/'+str(png_id)+'.png', OUTPUT_DIR+str(dirName)+'/'+str(png_id)+'.png');
	except Exception, e:
		print 'Error downloading the sticker: '+str(png_id);

def downloadExtra(sticker_id, ver, source, name, dirName, inmer):
	try:
		urllib.urlretrieve(BASE_URL+'/products/0/0/'+str(ver)+'/'+str(sticker_id)+'/'+source+'/'+name+'.png', OUTPUT_DIR+str(dirName)+'/'+name+'.png');
	except Exception, e:
		if inmer == 0:
			print 'Error downloading: '+name+'\r\nTrying to download from other source';
			downloadExtra(sticker_id, ver, ('android' if source == 'LINEStorePC' else 'iphone' ) , name, dirName, 1);

def forceUpgradeProductVersion(version):
	try:
		urllib.urlopen(BASE_URL+'/products/productVersions_'+str(version)+'.meta');
		version = forceUpgradeProductVersion(version + 1);
	except Exception, e:
		version = version - 1;
		downloadProductVersion(version);

	return version;

def downloadProductVersion(version):
	if os.path.isfile('./productVersions.meta'):
		os.remove('./productVersions.meta');

	try:
		urllib.urlretrieve(BASE_URL+'/products/productVersions_'+str(version)+'.meta', './productVersions.meta');
	except Exception, e:
		print 'productVersion.meta couldn\'t be done.';

def replace_all(text):
	nonValid = ['<', '>', ':', '"', '\\', '/', '|', '?', '*'];
	for i in xrange(0, len(nonValid)):
		if nonValid[i] in text:
			text = text.replace(nonValid[i], ' ');

	return text

if args.prodVer:
	latest = forceUpgradeProductVersion(int(config.get('aplication', 'prodVer')));
	config.set('aplication', 'prodVer', latest);
	config.write(open('sticker.cfg', 'wb'));
if args.sticker_id:
	main(args.sticker_id, args.tabs, args.ignore, int(config.get('aplication', 'prodVer')));
else :
	print "You should provide a sticker id with the param [-s].";