import tkinter as tk
import numpy as np
import pandas as pd
import math
from modules.nlp import NLP
from tkinter import filedialog
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer

class NLPs(NLP):
    def __init__(self):
        root = tk.Tk()
        root.withdraw()

        self.filePath = filedialog.askopenfilename()
        self.webs = list()
        self.contents = list()
        self.nlps = list()

    def __call__(self):
        self.readFile()
        self.wordFrequency()
        self.bagOfWords()
        self.tfIdf()

        print('DONE!')

    def readFile(self):
        f = open(self.filePath, 'r')
        lines = f.readlines()
        f.close()

        breakLine = True
        for line in lines:
            line = line.strip()

            if line:
                if breakLine:
                    self.webs.append([])
                    breakLine = False

                self.webs[-1].append(line)
            else:
                breakLine = True

    def wordFrequency(self):
        for i, web in enumerate(self.webs):
            nlp = NLP(web[0], web[1:], 'results/web_{0}'.format(i))
            nlp()
            self.contents.append(nlp.handleText)
            self.nlps.append(nlp)

    def bagOfWords(self):
        # creat text
        textData = np.array(self.contents)
        
        # creat the bag of words feature matrix
        count = CountVectorizer()
        bow = count.fit_transform(textData)
        
        # get feature name
        featureNames = count.get_feature_names()
       
        # create data frame
        res = pd.DataFrame(bow.toarray(), columns=featureNames)

        # writting file out
        res.to_csv('results/bow.csv', encoding='utf-8')

        # message
        print('The file writing process to results/bow.csv is complete.')

    def tfIdf(self):
        def computeTF(wordDict, bow):
            tfDict = dict()
            bowCnt = len(bow)

            for word, cnt in wordDict.items():
                tfDict[word] = cnt/float(bowCnt)

            return tfDict

        def computeIDF(docList):
            idfDict = dict()
            n = len(docList)

            idfDict = dict.fromkeys(docList[0].keys(), 0)
            for doc in docList:
                for word, cnt in doc.items():
                    if cnt > 0:
                        idfDict[word] += 1

            for word, cnt in idfDict.items():
                idfDict[word] = math.log(n/float(cnt))

            return idfDict

        def computeTfIdf(tfs, idfs):
            tfidf = dict()

            for word, val in tf.items():
                tfidf[word] = val*idfs[word]

            return tfidf

        wordDict = set()
        wordBows = list()
        tfs = list()
        tfidfs = list()

        for nlp in self.nlps:
            wordDict.update(list(nlp.wordFres.keys()))

        for i in range(len(self.nlps)):
            wordBow = dict.fromkeys(wordDict, 0)
            wordBows.append(wordBow)

        for word in wordDict:
            for i, nlp in enumerate(self.nlps):
                for key, val in nlp.wordFres.items():
                    wordBows[i][key] = val

        for i, wordBow in enumerate(wordBows):
            tf = computeTF(wordBow, list(self.nlps[i].wordFres.keys()))
            tfs.append(tf)

        idfs = computeIDF(wordBows)

        for tf in tfs:
            tfidf = computeTfIdf(tf, idfs)
            tfidfs.append(tfidf)

        res = pd.DataFrame(tfidfs)

        # writting file out
        res.to_csv('results/tfidf.csv', encoding='utf-8')

        # message
        print('The file writing process to results/tfidf.csv is complete.')
        