from modules.nlp import NLP

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
