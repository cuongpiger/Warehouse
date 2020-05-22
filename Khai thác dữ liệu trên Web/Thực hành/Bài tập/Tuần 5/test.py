""" 
from langdetect import detect
typeLang = detect('Dương Mạnh Cường đẹp trai vô địch siêu cấp vũ trụ.')
print(typeLang)
 """


from vncorenlp import VnCoreNLP
annotator = VnCoreNLP('D:\Warehouse\Khai thác dữ liệu trên Web\Thực hành\Bài tập\Tuần 5\misc\VnCoreNLP-1.1.1.jar', annotators="wseg,pos,ner,parse", max_heap_size='-Xmx2g')

print('ahjhj')
# Input 
text = "Ông Nguyễn Khắc Chúc  đang làm việc tại Đại học Quốc gia Hà Nội. Bà Lan, vợ ông Chúc, cũng làm việc tại đây."

# To perform word segmentation, POS tagging, NER and then dependency parsing
annotated_text = annotator.annotate(text)   

# To perform word segmentation only
word_segmented_text = annotator.tokenize(text)

print(word_segmented_text)