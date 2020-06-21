import numpy as np
import pandas as pd
import sys

from modules.nlp import NLP
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer

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
            print('1. Bag of words\n2. TF-IDF\n3. Both')
            choice = int(input('Do you want toWhat method do you want to use: ').strip())

            if choice == 1: self.bagOfWord()
            elif choice == 2: self.tfIdf()
            elif choice == 3:
                self.bagOfWord()
                self.tfIdf()
            else: print('Your choice is invalid!')

        # self.softCosineSimilarity()

    def bagOfWord(self):
        for path in self.paths:
            dataSets = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')
            
            for filePath in filePaths:
                textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                dataSets.append(textData)

            # create the bag of words feature matrix
            count = CountVectorizer(stop_words='english')
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
            tfidf = TfidfVectorizer(stop_words='english')
            data = tfidf.fit_transform(dataSets)

            # create data frame
            df = pd.DataFrame(data.toarray(), index=filePaths, columns=tfidf.get_feature_names())

            # write to csv file
            df.to_csv(f'{path}/tf-idf.csv')

    def cosineSimilarity(self):
        for path in self.paths:
            documents = list()
            sentences = list()
            filePaths = dt.getMultiFiles(f'{path}/sentence_tokenize')

            for filePath in filePaths:
                textData = dt.readTxt(f'{path}/sentence_tokenize/{filePath}')
                documents.append(textData)

            # prepare a dictionary and a corpus
            dictionary = corpora.Dictionary([simple_preprocess(doc) for doc in documents])

            # prepare the similarity matrix
            similarity_matrix = fasttext_model300.similarity_matrix(dictionary, tfidf=None, threshold=0.0, exponent=2.0, nonzero_limit=100)

            # convert the sentences into bag-opf-words vectors
            for doc in documents:
                sent = dictionary.doc2bow(simple_preprocess(doc))
                sentences.append(sent)

            len_array = np.arange(len(sentences))
            xx, yy = np.meshgrid(len_array, len_array)
            cossim_mat = pd.DataFrame([[round(softcossim(sentences[i],sentences[j], similarity_matrix) ,2) for i, j in zip(x,y)] for y, x in zip(xx, yy)], index=filePaths, columns=filePaths)

            cossim_mat.to_csv(f'{path}/cosine_similarity.csv')

