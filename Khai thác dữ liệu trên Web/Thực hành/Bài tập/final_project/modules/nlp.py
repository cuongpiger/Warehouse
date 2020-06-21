from langdetect import detect
from string import punctuation # list of special characters
from nltk.corpus import stopwords # english stopwords
from nltk.tokenize import sent_tokenize, word_tokenize
from nltk.stem import PorterStemmer # https://www.geeksforgeeks.org/python-stemming-words-with-nltk/

import pandas as pd
import sys

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

vnStopwords = dt.readTxt(r'data_config\vietnamese_stopwords_dash.txt').split('\n')
stopwords = [set(stopwords.words('english') + list(punctuation)), set(vnStopwords + list(punctuation))]
class NLP:
    def __init__(self, path):
        tmp = path.split('/')

        self.fullpath = path
        self.text = dt.readTxt(path)

        if self.text:
            self.path = '/'.join(tmp[:3])
            self.name = tmp[4]
            self.lang = 1 if detect(self.text) == 'vi' else 0

    def __call__(self):
        if self.text:
            self.sentenceTokenize()
            self.wordTokenize()
        else:
            print(f'Unfortunately, there was an error crawling at path {self.fullpath}!')

    def sentenceTokenize(self):
        text = sent_tokenize(self.text)
        text = list(map(lambda s: dt.removeSpecialChars(s), text))
        text = '\n'.join(text)

        dt.writeTxt(f'{self.path}/sentence_tokenize/{self.name}', 'w', text, False)       

    def wordTokenize(self):
        ps = PorterStemmer()
        word_fres = dict()
        words = None

        if self.lang == 0:
            para = dt.readTxt(f'{self.path}/clear/{self.name}')
            words = word_tokenize(para)
            words = [ps.stem(word.lower()) for word in words if word.lower() not in stopwords[self.lang]]

        for word in words:
            word_fres[word] = word_fres.get(word, 0) + 1

        data = {'Word': list(word_fres.keys()), 'Frequency': list(word_fres.values())}

        df = pd.DataFrame.from_dict(data)
        df.to_csv(f'{self.path}/word_tokenize/{self.name[:-4]}.csv')
