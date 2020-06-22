from modules.nlps import NLPs

tmp = NLPs(['results/vnexpress.net/doi-song'])
tmp.bagOfWord()
tmp.tfIdf()
tmp.cosineSimilarity()