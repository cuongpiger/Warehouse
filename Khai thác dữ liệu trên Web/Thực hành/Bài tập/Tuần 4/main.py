import tkinter as tk
import os
import numpy as np
from tkinter import filedialog
from sklearn.feature_extraction.text import CountVectorizer, TfidfVectorizer

class Solution:
    def __init__(self):
        root = tk.Tk()
        root.withdraw()

        self.direcPath = filedialog.askdirectory()
        self.listFiles = list()
        self.getFiles()

        if self.direcPath:
            print('Getting all file at directory: {0}'.format(self.direcPath))
            print('All files from directory {0} are:'.format(self.direcPath))

            for file in self.listFiles:
                print(file)

            self.contents = self.readText()

    def __call__(self):
        self.bagsOfWords()
        self.tfIdf()

    def getFiles(self):
        for root, dirs, files in os.walk(self.direcPath):
            for file in files:
                self.listFiles.append(file)

    def readText(self):
        contents = list()

        for file in self.listFiles:
            readFile = open(self.direcPath + '/' + file, 'r')
            text = readFile.read()
            contents.append(text)

        return contents

    def bagsOfWords(self):
        result = CountVectorizer()
        todens = result.fit_transform(self.contents).todense()
        res = ''

        for file, toden in zip(self.listFiles, todens):
            aLine = file + ' ' + ' '.join(map(str, np.array(toden)[0].tolist())) + '\n'
            res += aLine

        f = open('./results/bow.txt', 'w')
        f.write(res)
        f.close()

    def tfIdf(self):
        tf = TfidfVectorizer(analyzer='word', ngram_range=(1, 3), min_df=0, stop_words='english')
        tf_idf_matrix = tf.fit_transform(self.contents)
        feature_names = tf.get_feature_names()
        dense = tf_idf_matrix.todense()

        f = open('./results/tfidf_feature_name.txt', 'w')
        f.write('\n'.join(feature_names))
        f.close()
        print(tf_idf_matrix)
        print(dense)
        
sol = Solution()
sol()