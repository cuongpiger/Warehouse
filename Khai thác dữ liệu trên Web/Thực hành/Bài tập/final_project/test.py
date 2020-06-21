# import os

# listPath = []

# for root, dirs, files in os.walk('results/vietnamnews.vn/politics-laws'):
#     for file in files:
#         print(file)

from modules.nlps import NLPs

tmp = NLPs(['results/vietnamnews.vn/politics-laws'])
tmp.tfIdf()