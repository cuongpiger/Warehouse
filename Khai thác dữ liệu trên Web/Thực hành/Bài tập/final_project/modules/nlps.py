import numpy as np
import pandas as pd
import sys

from modules.nlp import NLP
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity

sys.path.insert(1, 'utilities')
import data as dt, misc as msc

class NLPs(NLP):
    def __init__(self, paths):
        self.paths = paths
        self.lang = 0

    # the main method, call in main.py
    def __call__(self):
        for path in self.paths:
            listFiles = dt.getMultiFiles(f'{path}/clear')

            for file in listFiles:
                nlp = NLP(f'{path}/clear/{file}')
                nlp()
                
                self.lang = nlp.lang

        tmp = input('Do you want to perform texts in vector space? [y/n]: ').strip().lower()

        if tmp == 'y':
            print('1. Bag of words\n2. TF-IDF\n3. Both')
            choice = int(input('Do you want toWhat method do you want to use: ').strip())

            if choice == 1: self.bagOfWord()
            elif choice == 2: self.tfIdf()
            elif choice == 3:
                self.bagOfWord()
                self.tfIdf()
            else: print('Your choice is invalid!')

        self.cosineSimilarity()

    def bagOfWord(self):
        for path in self.paths:
            dataSets = list()
            fpaths = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = None

                if self.lang == 0:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                elif 'dash_' in filePath:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')

                if textData != '': 
                    dataSets.append(textData)
                    fpaths.append(filePath)

            if len(dataSets) != 0:
                # create the bag of words feature matrix
                count = CountVectorizer(stop_words='english') if self.lang == 0 else CountVectorizer()
                bow = count.fit_transform(dataSets)

                # create data frame
                df = pd.DataFrame(bow.toarray(), index=fpaths, columns=count.get_feature_names())

                # write to csv file
                df.to_csv(f'{path}/bag-of-words.csv')

    def tfIdf(self):
        for path in self.paths:
            dataSets = list()
            fpaths = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = None

                if self.lang == 0:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                elif 'dash_' in filePath:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')

                if textData != '': 
                    dataSets.append(textData)
                    fpaths.append(filePath)

            if len(dataSets) != 0:
            # create the bag of words feature matrix
                tfidf = TfidfVectorizer(stop_words='english') if self.lang == 0 else TfidfVectorizer()
                data = tfidf.fit_transform(dataSets)

                # create data frame
                df = pd.DataFrame(data.toarray(), index=fpaths, columns=tfidf.get_feature_names())

                # write to csv file
                df.to_csv(f'{path}/tf-idf.csv')

    def cosineSimilarity(self):
        for path in self.paths:
            dataSets = list()
            fpaths = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = None

                if self.lang == 0:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                elif 'dash_' in filePath:
                    textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                    
                if textData != '': 
                    dataSets.append(textData)
                    fpaths.append(filePath)

            if len(dataSets) != 0:
            # create the bag of words feature matrix
                tfidf = TfidfVectorizer(stop_words='english') if self.lang == 0 else TfidfVectorizer()
                sparse_matrix = tfidf.fit_transform(dataSets)
                doc_term_matrix = sparse_matrix.todense()

                # create data frame
                df = pd.DataFrame(doc_term_matrix, index=fpaths, columns=tfidf.get_feature_names())
                df = pd.DataFrame(cosine_similarity(df), index=fpaths, columns=fpaths)

                # write to csv file
                df.to_csv(f'{path}/cosine-similarity.csv')

