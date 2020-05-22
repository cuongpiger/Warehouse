import tkinter as tk
import numpy as np
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

    def __call__(self):
        self.readFile()
        self.wordFrequency()
        self.bagOfWords()

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
            self.contents.append(' '.join(nlp.sentsCleaned).lower())

    def bagOfWords(self):
        results = CountVectorizer()
        todens = results.fit_transform(self.contents).todense()
        writtenData = ''

        for i, toden in enumerate(todens):
            line = 'web_{0}'.format(i) + ' ' + ' '.join(map(str, np.array(toden)[0].tolist())) + '\n'
            writtenData += line

        f = open('results/bow.txt', 'w', encoding='utf8')
        f.write(writtenData)
        f.close()

        print('The file writting process to results/bow.txt is complete.')

            

            

