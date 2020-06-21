# import os

# listPath = []

# for root, dirs, files in os.walk('results/vietnamnews.vn/politics-laws'):
#     for file in files:
#         print(file)

# from modules.nlps import NLPs

# tmp = NLPs(['results/vietnamnews.vn/politics-laws'])
# tmp.tfIdf()

import fasttext
import fasttext.util
tmp = fasttext.load_model('misc/cc.en.300.bin').get_nearest_neighbors('hello')
print(tmp)
# import gensim.downloader as api

# print('ahjhj')

# model = api.load("fasttext-wiki-news-subwords-300")
# model.most_similar(positive=["russia", "river"])

# print('jhaha')