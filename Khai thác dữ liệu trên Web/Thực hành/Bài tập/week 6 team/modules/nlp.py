import nltk # the natural language processing packege for python
import re # help to solve the regular expression problem
import os # module of system
from requests_html import HTMLSession # get raw file HTML from URL
from bs4 import BeautifulSoup # remove all HTML tags in raw file HTML
from string import punctuation # list of special characters
from nltk.corpus import stopwords # english stopwords
from nltk.tokenize import word_tokenize, sent_tokenize # https://www.nltk.org/_modules/nltk/tokenize.html
from nltk.stem import PorterStemmer # https://www.geeksforgeeks.org/python-stemming-words-with-nltk/
from langdetect import detect # this package is used to detect the language of the text
from vncorenlp import VnCoreNLP # this packege is used to split a vietnamese sentence into set of words

# function to creat a list of vietnamese stopwords by reading file vietnamese_stopwords_dash.txt
def readVietnameseStopwords():
    f = open('./misc/vietnamese_stopwords_dash.txt', 'r', encoding='utf-8')
    vnStopwords = f.read()
    f.close()

    return list(vnStopwords.split('\n'))

class NLP:
    # `url`: link to website; `tags`: list of CSS selectors which users need to explore
    def __init__(self, url, sels, savePath):
        self.url = url
        self.sels = sels
        self.rawHtml = None
        self.savePath = savePath
        self.stopwords = [set(stopwords.words('english') + list(punctuation)), set(readVietnameseStopwords() + list(punctuation))] # set of english + special character stopwords and set of vietnamese + special character
        
    # the main method, call to solve the problem after use method constructor
    def __call__(self):
        self.getRawHtml()
        self.writeFile(self.savePath + '/raw_html.txt', self.rawHtml)

        self.cleanHtml()
        self.writeFile(self.savePath + '/clean_html.txt', self.cleanHtml)

        self.langDetect()
        self.sentsOrigin = sent_tokenize(self.cleanHtml)
        self.writeFile(self.savePath + '/sents_origin.txt', '\n'.join(self.sentsOrigin))

        self.sentencesCleaned()
        self.writeFile(self.savePath + '/sents_cleaned.txt', ' '.join(self.sentsCleaned))

        # handle the word and frequency for website
        self.wordFrequency()
        self.writeFile(self.savePath + '/word_frequency.txt', '\n'.join(['{0} - {1}'.format(k, v) for k, v in self.wordFres.items()]))
        
    # method to write content from a class's  atrribute with `path`: is the path so save this file and `data` is the data needs to be write
    def writeFile(self, path, data):
        os.makedirs(os.path.dirname(path), exist_ok=True)

        with open(path, 'w', encoding='utf-8') as f:
            f.write(data)
            f.close()

        print('The file writing process to {0} is complete.'.format(path))

    # method to get raw html file from an `self.url` then assigning to atrribute `self.rawHtml`
    def getRawHtml(self):
        # config
        ss = HTMLSession()
        req = ss.get(self.url)
        raw = list()

        # if users provide css selectors to extract
        if len(self.sels):
            for sel in self.sels:
                posts = req.html.find(sel)

                for post in posts:
                    raw.append(post.html)
        else: # get the entire website
            raw.append(req.text)

        self.rawHtml = '\n'.join(map(str, raw))

    # remove all html tags then returning text, format text for nice
    def cleanHtml(self):
        # extract text by removing all html tags
        text = BeautifulSoup(self.rawHtml, 'html.parser').get_text().strip()

        # enter each line of `text` and delete extra space at head an tail of each line, method spitlines separate the paragraph base on character '\n'
        lines = (line.strip() for line in text.splitlines())

        # for each line, split it base on string '  ' (2 spaces)
        chunks = (phrase.strip() for line in  lines for phrase in line.split('  '))

        # for each chunk, it chunk != '', then pushing it into `cleanHtml`
        self.cleanHtml = '\n'.join(chunk for chunk in chunks if chunk)

    # detect the website's content is vietnamese or english
    def langDetect(self):
        self.lang = 1 if detect(self.cleanHtml) == 'vi' else 0

    # remove all special character
    # to find out more, following this link: https://repl.it/@cuongpiger/giai-thich-regular-expression
    def removeSpecialChars(self, text):
        string = re.sub('[^\w\s]', '', text)
        string = re.sub('\s+', ' ', string)
        string = string.strip()

        return string

    # remove all break line
    def sentencesCleaned(self):
        self.sentsCleaned = [self.removeSpecialChars(s) for s in self.sentsOrigin]

    # handle word - frequency for English text
    def wordFrequency(self):
        ps = PorterStemmer()
        wordFres = dict()
        words = None

        if self.lang == 0:
            words = word_tokenize(' '.join(self.sentsCleaned))
            words = [ps.stem(word.lower()) for word in words if word.lower() not in self.stopwords[self.lang]]
        else:
            annotator = VnCoreNLP("VnCoreNLP-1.1.1.jar", annotators="wseg,pos,ner,parse", max_heap_size='-Xmx2g')

            words = annotator.tokenize(' '.join(self.sentsCleaned))
            words = words[0]
            words = [word.lower() for word in words if word.lower() not in self.stopwords[self.lang]]

        for word in words:
            wordFres[word] = wordFres.get(word, 0) + 1

        self.wordFres = wordFres
        self.handleText = ' '.join(words)