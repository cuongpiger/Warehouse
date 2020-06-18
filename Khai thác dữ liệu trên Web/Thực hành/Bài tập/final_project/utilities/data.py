import json, shutil, os

# used to read data from a json file
def readJson(filepath):
    data = []

    with open(filepath) as jsonFile:
        data = json.load(jsonFile)

    return data

def writeJson(filepath, option, data):
    with open(filepath, option) as jsonFile:
        json.dump(data, jsonFile)

def writeTxt(filepath, option, data):
    f = open(filepath, option)
    f.write(data)
    f.close()

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