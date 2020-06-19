import json, shutil, os

def removeSpecialChars(text):
    import re

    string = re.sub('[^\w\s]', '', text)
    string = re.sub('\s+', ' ', string)
    string = string.strip()

    return string

# used to read data from a json file
def readJson(filepath):
    data = []

    with open(filepath, encoding='utf-8') as jsonFile:
        data = json.load(jsonFile)

    return data

def readTxt(filepath):
    text = ''

    with open(filepath, 'r', encoding='utf-8') as file:
        text = file.read()

    return text


def writeJson(filepath, option, data):
    with open(filepath, option, encoding='utf-8') as jsonFile:
        json.dump(data, jsonFile)

def writeTxt(filepath, option, data, remove):
    with open(filepath, option, encoding='utf-8') as txtFile:
        data = json.dumps(data, ensure_ascii=False).encode('utf-8').decode()
        
        if remove:
            data = removeSpecialChars(data)

        txtFile.write(data)

def cleanFolder(path):
    for filename in os.listdir(path):
        file_path = os.path.join(path, filename)

        try:
            if os.path.isfile(file_path) or os.path.islink(file_path):
                os.unlink(file_path)
            elif os.path.isdir(file_path):
                shutil.rmtree(file_path)
        except Exception as e:
            print('Failed to delete %s. Reason: %s' % (file_path, e))
            