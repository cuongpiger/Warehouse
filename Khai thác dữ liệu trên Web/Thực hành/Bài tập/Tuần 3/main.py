import nltk
import re
import os
from requests_html import HTMLSession # a package helps that get raw file html file from an url
from bs4 import BeautifulSoup # a package helps clearing extract text out original raw html file
from string import punctuation # https://www.geeksforgeeks.org/string-punctuation-in-python/
from nltk.corpus import stopwords # store stopwords
from nltk.tokenize import word_tokenize, sent_tokenize # https://www.nltk.org/_modules/nltk/tokenize.html
from nltk.stem import PorterStemmer # https://www.geeksforgeeks.org/python-stemming-words-with-nltk/

# main class
class DataPreprocessing:
    # `url`: link to website, `tags`: an array contains element HTML tags which the user want to explore
    def __init__(self, url, tags):
        self.url = url
        self.tags = tags
        self.rawHtml = None
        self.stopwords = set(stopwords.words('english') + list(punctuation)) # set of stopwords

    # the main method, call to solve the problem after use method constructor
    def __call__(self):
        self.getRawHtml()
        self.writeFile('./results/raw_html.txt', self.rawHtml)

        self.cleanHtml()
        self.writeFile('./results/clean_html.txt', self.cleanHtml)

        self.sentsOrigin = sent_tokenize(self.cleanHtml)
        self.writeFile('./results/sents_origin.txt', '\n'.join(self.sentsOrigin))

        self.sentencesCleaned()
        self.writeFile('./results/sents_cleaned.txt', ' '.join(self.sentsCleaned))

        self.wordFrequency()
        self.writeFile('./results/word_frequency.txt', '\n'.join(['{0} - {1}'.format(k, v) for k, v in self.wordFres.items()]))

    # method to get raw html file from an `self.url` then assigning to attribute `self.rawHtml`
    def getRawHtml(self):
        ss = HTMLSession()
        req = ss.get(self.url)
        texts = list()

        # if user provide what css selector to extract
        if len(self.tags):
            for tag in self.tags:
                posts = req.html.find(tag)

                for post in posts:
                   texts.append(post.html)
        else:
            # else get the entire website
            texts.append(req.text)

        self.rawHtml = '\n'.join(map(str, texts))
        
    # method to write content from a class's attribute where `fileName`: is the path so save this file
    #   and `data` is the data needs to be write
    def writeFile(self, fileName, data):
        f = open(fileName, 'w', encoding='utf-8')
        f.write(data)
        f.close()

    # remove all html tags then returning text, format text for nice
    def cleanHtml(self):
        # extract text by removing all html tags
        texts = BeautifulSoup(self.rawHtml, 'html.parser').get_text().strip()
        # enter each line of `texts` and delete extra space at head and tail of each line, method splitlines separate the paragraph base on character '\n'
        lines = (line.strip() for line in texts.splitlines())

        # for each line, split it base on string '  ' (2 space)
        chunks = (phrase.strip() for line in lines for phrase in line.split('  '))

        # for each chunk, if chunk != '', then pushing it to `cleanHtml`
        self.cleanHtml = '\n'.join(chunk for chunk in chunks if chunk)

    def removeSpecialChars(self, text):
        string = re.sub('[^\w\s]', '', text)
        string = re.sub('\s+', ' ', string)
        string = string.strip()

        return string

    def sentencesCleaned(self):
        self.sentsCleaned = [self.removeSpecialChars(s) for s in self.sentsOrigin]

    def wordFrequency(self):
        ps = PorterStemmer()
        wordFres = dict()

        words = word_tokenize(' '.join(self.sentsCleaned))
        words = [ps.stem(word.lower()) for word in words if word.lower() not in self.stopwords]

        for word in words:
            wordFres[word] = wordFres.get(word, 0) + 1

        self.wordFres = wordFres


# main
# dtp = DataPreprocessing('https://techcrunch.com/', ['.post-block__content', '.river-byline__authors'])
dtp = DataPreprocessing('https://techcrunch.com/', [])
dtp()