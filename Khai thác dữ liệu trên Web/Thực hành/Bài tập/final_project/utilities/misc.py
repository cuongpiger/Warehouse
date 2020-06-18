def getCategory(path):
    return path.split('/')[-1]

def getDomainName(url):
    from tld import get_tld

    return get_tld(url, as_object=True).fld