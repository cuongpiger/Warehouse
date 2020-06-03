#  Nhóm 1: 
## Thành viên:
* 1760171 - Nguyễn Minh Tâm
* 1760189 - Võ Sĩ Thiên
* 1760273 - Dương Mạnh Cường
  
#<center> DEADLINE nhóm tuần 5</center>

## 1. Cấu hình:
Trước khi chạy phần mềm này cần cài đặt một số package cần thiết:
* Python 3.6 (hoặc cao hơn) và một số package cần cài đặt:
  * [nltk](https://pypi.org/project/nltk/) `pip install nltk`.
  * [requests_html](https://pypi.org/project/requests-html/) `pip install requests-html` (lưu ý, nếu bạn chạy python trên environment anaconda, thì trong các package mà anaconda hỗ trợ sẽ không có package này, bạn cần config lại environtment trong **System properties**, tại phần ***Path***, bạn đưa đường dẫn đến Python thuần lên đầu tiên).
  * [bs4](https://pypi.org/project/bs4/) `pip install bs4`.
  * [sklearn](https://pypi.org/project/scikit-learn/) (bạn nên follow theo các bước tại [trang này](https://calebshortt.com/2016/01/15/installing-scikit-learn-python-data-mining-library/?fbclid=IwAR0kICcfhFcZiaRxTxSXl62ub3y10XwUMg_QEqDC3goo99uDFhnvWqU7rQo) để cài đặt).
  * [langdetect](https://pypi.org/project/langdetect/) `pip install langdetect`
  * [vncorenlp](https://github.com/vncorenlp/VnCoreNLP) `pip install vncorenlp`
  * [numpy](https://pypi.org/project/numpy/) `pip install numpy`
  * [pandas](https://pypi.org/project/pandas/) `pip install pandas`
* Java 1.8 (download và cài đặt [tại đây](https://www.oracle.com/java/technologies/javase/javase-jdk8-downloads.html)) (có thể dùng phiên bản cao hơn).
* Bạn cần truy cập vào [trang này](https://github.com/vncorenlp/VnCoreNLP) và download zip (1) package trên đây. Giải nén ra và giữ lại các file (2), (3) mà mình đã tô đỏ, xóa các file còn lại đi.
  ![](https://f24-zpg.zdn.vn/6495283539332635159/b112df4cfcd1068f5fc0.jpg)
* Cuối cùng bạn được cây thư mục như vầy:
  ![](https://f27-zpg.zdn.vn/8149475308597219191/61e5af950931f36faa20.jpg)

  Trong đó folder ***models*** và file ***VnCoreNLP-1.1.1.jar*** chính là (2) và (3) mà mình nhờ các bạn tải từ trang github ở bước trước.
## 2. Chạy chương trình:
### 2.1. Cấu hình file input.txt
Đây chính là nội dung của file ***en.txt*** mà các bạn thấy trong folder input trong cây thư mục.
![](https://f29-zpg.zdn.vn/5867251778297200192/1afa0140a0e45aba03f5.jpg)

* Ở đây dữ liệu mình truyền vào dưới dạng url, như bạn thấy mình lấy dữ liệu từ 2 trang là *techcrunch.com* và *ted.com* ở lần lượt các dòng là 1 và 5, ở dòng 4 có một break line như vậy để nói chương trình hiểu là tôi đã cấu hình xong những cái tôi cần cho một trang web rồi.
* Ở các dòng 3 và 4, bạn sẽ thấy hơi kì lạ đây chính là các **CSS classes**, tức nếu như bạn không muốn lấy toàn bộ file raw của một trang HTML nào đó, bạn hoàn toàn có thể tìm các **CSS classes** này để điền vào đây, chương trình sẽ tự động lấy các nội dung trong các thẻ HTML có các **CSS classes** này đính kèm. Còn nếu bạn muốn lấy toàn bộ trang web thì không cần điền bất cứ gì vào cả.

### 2.2. Run:
**LƯU Ý**: nếu đây là lần đầu bạn chạy chương trình này, bạn cần chạy file ***setup.py*** đầu tiên để tiến hành install một vài module cần thiết như bộ *stopwords* cho tiếng anh, sau khi chạy file ***setup.py***, một dialog sẽ hiện lên như vầy:
![](https://f26-zpg.zdn.vn/3430714110328706742/54d0a9ae2d0ad7548e1b.jpg)
Bạn có thể tìm kiếm module tên là ***stopwords*** rồi **Download** nó về, nhưng nếu bạn làm biếng giống mình, bạn chọn ***all*** => **Download**. Ở đây do mình đã download hoàn tấn (xanh hết các module), bạn tắt dialog này đi và thực hiện theo các bước phía dưới.
* ***Bước 1***: Các bạn truy cập vào folder chính (ở đây folder hiện tại là mình đặt là **week_5**, có thể khi nộp bài mình sẽ chỉnh lại cho hợp quy tắc nộp bài).
![](https://f29-zpg.zdn.vn/2729427518340791352/669f001db6b94ce715a8.jpg)
* ***Bước 2***: Tại đây các bạn mở terminal lên, ghõ lệnh `python main.py`, một dialog sẽ mở ra, các bạn chọn đến file input mà mình đã hướng dẫn các bạn cấu hình bên trên, các bạn hoàn toàn có thể chọn một file khác ở một vùng nhớ nào khác trong máy bạn, không nhất thiết là phải đặt nó vào folder ***input*** như trong cây thư mục của mình.
  ![](https://f29-zpg.zdn.vn/3709711026886004848/9c4fc1704fd4b58aecc5.jpg)
  Mình chọn file ***input/en.txt*** và chọn **OPEN**
  ![](https://f24-zpg.zdn.vn/1391127233206534167/dcb248e1c5453f1b6654.jpg)
  Sau khi các bạn thấy terminal reply lại `DONE!` thì bây giờ bạn access vào folder ***results*** (xem lại trên cây thư mục) để xem kết quả.
  ![](https://f31-zpg.zdn.vn/6081207806550966715/c9cc5669dccd26937fdc.jpg)

## 3. Xem kết quả:
Trong thư mục ***results*** sau khi chạy các bạn thu được các file như sau:
![](https://f27-zpg.zdn.vn/4901583652990868059/afb65ac3c4673e396776.jpg)

Trong đó các folder như **web_0** và **web_1** lần lượt là các output cho 2 url *techcrunch.com* và *ted.com*, bây giờ mình sẽ diễn giải cho folder **web_0** (**web_1** tương tự).
  * file ***raw_html.txt***, là output ghi ra sau khi lấy dữ liệu raw từ url.
    ![](https://f28-zpg.zdn.vn/1243786903260448910/d2e3ebf67252880cd143.jpg)
  * file ***clean_html.txt***, là output ghi ra sau khi xóa tất cả các thẻ HTML.
    ![](https://f30-zpg.zdn.vn/9206744890356068288/470e600df6a90cf755b8.jpg)
  * file ***sents_origin.txt***, là output ghi ra sau khi tách các paragraph thành các đoạn.
    ![](https://f31-zpg.zdn.vn/4693574172612765203/b507e74174e58ebbd7f4.jpg)
  * file ***sents_cleaned.txt***, là output ghi ra sau khi xóa các special character, các khoảng trắng dư thừa.
    ![](https://f31-zpg.zdn.vn/5383511323365976590/acf534d4a5705f2e0661.jpg)
  * file ***word_frequency.txt***, là file thể hiện pair word - frequency sau khi lower, loại bỏ stopword, stemming (đối với tiếng anh).
    ![](https://f28-zpg.zdn.vn/1257685239360212575/e74e28f2c7563d086447.jpg)
  * file ***bow.csv*** là file kết quả của phương pháp Bag of words. Với index dòng là thể hiện theo thứ tự url trong file input. Cột là các từ
    ![](https://b-f25-zpg.zdn.vn/3759676337494580920/8be59d2e708a8ad4d39b.jpg)
  * file ***tfidf.csv*** là file kết quả của phương pháp TF-IDF. Tại đây dòng cũng là các url và cột là các từ. Kết quả các bạn thấy đa phần được làm tròn do extension quy định, mình không biết chỉnh lại như thế nào nhưng nếu các bạn xem trên excel thì số sẽ rất lẽ và xấu.
    ![](https://f29-zpg.zdn.vn/3090931627046997185/5e48c4d32e77d4298d66.jpg)
