import json

# used to read data from a json file
def readJson(filepath):
    data = []

    with open(filepath) as jsonFile:
        data = json.load(jsonFile)

    return data

def writeJson(filepath, option, data):
    with open(filepath, option) as jsonFile:
        json.dump(data, jsonFile)
