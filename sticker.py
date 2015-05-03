import urllib
import json
import sys, os

BASE_URL = 'http://dl.stickershop.line.naver.jp';
OUTPUT_DIR = './';

def main(sticker_id):
	comp = getMeta(sticker_id); 
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
			downloadSticker(sticker_id, png_id, dirName)
			print "[%3.2f%%]" % ((i * 100) / (nStickers -1))," Downloaded         \r",

		print "";
		print "Download complete";
		writeMeta(metaStr, dirName+'/productInfo.meta');

def getMeta(sticker_id):
	meta = None;
	metaStr = None;
	try:
		url = urllib.urlopen(BASE_URL+'/products/0/0/1/'+str(sticker_id)+'/android/productInfo.meta');
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

def downloadSticker(sticker_id, png_id, dirName):
	try:
		urllib.urlretrieve(BASE_URL+'/products/0/0/1/'+str(sticker_id)+'/android/stickers/'+str(png_id)+'.png', OUTPUT_DIR+str(dirName)+'/'+str(png_id)+'.png');
	except Exception, e:
		print 'Error downloading the sticker: '+str(png_id);


def replace_all(text):
	nonValid = ['<', '>', ':', '"', '\\', '/', '|', '?', '*'];
	for i in xrange(0, len(nonValid)):
		if nonValid[i] in text:
			text = text.replace(nonValid[i], ' ');

	return text

if len(sys.argv) > 1:
	main(sys.argv[1]);
else:
	print "You should provide a sticker id in order to download'it.";