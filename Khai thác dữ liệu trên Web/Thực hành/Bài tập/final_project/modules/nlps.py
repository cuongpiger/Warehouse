from modules.nlp import NLP
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer

import numpy as np
import pandas as pd
import sys

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

class NLPs(NLP):
    def __init__(self, paths):
        self.paths = paths

    # the main method, call in main.py
    def __call__(self):
        for path in self.paths:
            listFiles = dt.getMultiFiles(f'{path}/clear')

            for file in listFiles:
                nlp = NLP(f'{path}/clear/{file}')
                nlp()

        tmp = input('Do you want to perform texts in vector space? [y/n]: ').strip().lower()

        if tmp == 'y':
            print('1. Bag of words\n2. TF-IDF')
            choice = int(input('Do you want toWhat method do you want to use: ').strip())

            if choice == 1: self.bagOfWord()
            elif choice == 2: self.tfIdf()
            else: print('Your choice is invalid!')



    def bagOfWord(self):
        for path in self.paths:
            dataSets = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                dataSets.append(textData)

            # create the bag of words feature matrix
            count = CountVectorizer()
            bow = count.fit_transform(dataSets)

            # create data frame
            df = pd.DataFrame(bow.toarray(), index=filePaths, columns=count.get_feature_names())

            # write to csv file
            df.to_csv(f'{path}/bag_of_words.csv')

    def tfIdf(self):
        for path in self.paths:
            dataSets = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                dataSets.append(textData)

            # create the bag of words feature matrix
            tfidf = TfidfVectorizer()
            data = tfidf.fit_transform(dataSets)

            # create data frame
            df = pd.DataFrame(data.toarray(), index=filePaths, columns=tfidf.get_feature_names())

            # write to csv file
            df.to_csv(f'{path}/tf-idf.csv')
