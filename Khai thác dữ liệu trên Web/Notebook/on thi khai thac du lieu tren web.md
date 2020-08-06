<center>

# ÔN THI CUỐI KÌ MÔN<br>KHAI THÁC DỮ LIỆU TRÊN WEB

<small><strong>Author:</strong> Manh Cuong</small>

</center>

# 1. Khai thác nội dung Web:
## 1.1. Thế nào là khai thác nội dung Web?
* Khai thác nội dung Web bao gồm 3 nhánh lớn:
  * Khai thác nội dung trên 1 trang web nào đó
    > * Mục tiêu là rút trích tri thức hữu ích từ nội dung của các tài liệu Web. Dữ liệu web (hay còn gọi là tài liệu web) bao gồm văn bản, hình ảnh, âm thanh, video hoặc bản tin cấu trúc (danh sách, bảng biểu).
    > * Bài toán cần sự hỗ trợ của các kĩ thuật truy tìm thông tin và xử lí ngôn ngữ tự nhiên như:
    >   * Các mô hình truy vấn thông tin và độ đo đánh giá.
    >   * Kĩ thuật xử lí văn bản: stemming, pos-tagging,...
  * Khai thác cấu trúc web
  * Khai thác hành vi trên web

## 1.2. Ứng dụng của khai thác nội dung Web:
* Nhận diện các chủ đề trong tài liệu Web, phân loại/gom nhóm các trang web theo chủ đề.
  Ví dụ: ta có 1 bài viết, ta cần phân loại bài viết đó thuộc vào các mục nào như: Thể thao, Văn hóa, Đời sống,...
* Phát hiện ra trang web có bị trùng hay ko: hỗ trợ cho quá trình đánh chỉ mục, xác định vi phạm bản quyền.
  Ví dụ: 
    * 1 trang web A nào đó đã sao chép nội dụng của một trang web B nào đó (hay còn gọi là trang web A này tiến hành đăng lại nội dung từ trang web B).
    * Xem một trang web A nào đó có giả dạng một trang web B nào đó hay ko, những trường hợp phổ biến là giả dạng trang web ngân hàng, trang web chơi game,...
* Truy vấn thông tin: đưa vào câu truy vấn, hệ thống sẽ trả về nội dung các trang web có liên quan đến câu truy vấn đó.
  Ví dụ: công cụ tìm kiếm của Google.
* Tìm kiếm các nhận xét về một sản phẩm: (từ các trang bán hàng, blog, forum,...) phân tích và cải tiến sản phẩm, tìm hiểu sở thích người dùng.
  Ví dụ: trong kinh doanh, sẽ tiến hành thu thập ý kiến của người dùng để có thể cải tiến sản phẩm này trong tương lai.

# 2. Các kĩ thuật tiền xử lí:
## 2.1. Tiền xử lí văn bản:
Các bước:
  - Rút trích từ: dễ dàng đối với tiếng Anh
  - Loại bỏ **stopword**
    Ví dụ: a, an, the, will, with,...
  - **Stemming**: chuyển biến thể từ về thể gốc
    Ví dụ: going &rarr; go, went &rarr; go
  - Đếm số lần xuất hiện từ và tính trọng số từ bằng phương pháp **TF-IDF**
  - Kỹ thuật khác: loại bỏ dấu câu, xử lí chữ HOA/thường
  
### 2.1.1. Stopword:
* Là các từ xuất hiện thường xuyên trong câu, giúp xây dựng câu nhưng ko biểu đạt nội dung của tài liệu.
  Ví dụ: a, an, are, about, at, as,...
* Tác hại của việc ko loại bỏ stopword là khiến cho tài liệu của chúng ta chứa nhiều từ nhưng về mặt ý nghĩa thì ko có nhiều từ đó dẫn đến việc thời gian chạy các thuật toán sẽ lâu hơn.
* Danh sách của 1 stopword có thể dc xây dựng dưa trên đặc trưng cho mỗi ứng dụng.
  Ví dụ: từ '**a**' trong tiếng Anh là stopword, nhưng đối với tài liệu này từ '**a**' này là từ quan trọng, nên nó dc loại bỏ khỏi stopword.
* Stopword cần dc loại bỏ trc khi câu dc đánh chỉ mục và lưu trữ.
* Câu truy vấn cũng cần phải dc loại bỏ stopword.
* Tại sao cần phải loại bỏ stopword?
  * Giảm dc kích thước của tập tin chỉ mục (hoặc tài liệu): stopword chiếm từ 20-30% tổng số từ chứa trong tài liệu.
  * Tăng hiệu suất và hiệu quả: stopword gây nhiễu cho quá trình tìm kiếm và khai thác văn bản và giúp cải thiện tốc độ của thuật toán lên.

### 2.1.2. Stemming:
* Trong ngôn ngữ (đặc biệt là tiếng Anh), một từ có thể có nhiều cú pháp khác nhau phụ thuộc vào ngữ cảnh sử dụng.
  Ví dụ (trong tiếng Anh):
    * Danh từ có thể là số ít hoặc số nhiều: '**apple**' và '**apples**'
    * Động từ có thể nguyên bản hoặc tiếp diễn (**_+ing_**): '**eat**' và '**eating**'
    * Động từ ở các thể khác nhau: '**eat**', '**ate**' và '**eaten**'
* Ảnh hưởng của stemming: 
  * Các thể cú pháp của 1 từ dc xem như những biến thể của cùng 1 thể gốc.
  * Những biến thể này làm giảm độ bao phủ (**recall**) của hệ thống truy vấn, tức là tài liệu liên quan có thể chứa biến thể của từ truy vấn nhưng ko phải từ gốc.
  * Các vấn đề này có thể giải quyết một phần bằng phương pháp **stemming**.
* Lợi ích của stemming: 
  * Stemming giúp tăng hiệu quả truy vấn và khai thác văn bản, so khớp các từ tương tự, cải thiện độ bao phủ.
  * Stemming làm giảm kích thước của cấu trúc đánh chỉ mục, kết hợp các từ có chung thể gốc có thể làm giảm kích thước của chỉ mục đến 40-50%.
* Bất lợi của phương pháp stemming:
  * Ảnh hưởng đến độ chính xác vì tài liệu ko liên quan cũng bị xem là có liên quan.
    Ví dụ: '**cop**' và '**cope**', từ '**cope**' sau stemming sẽ thành '**cop**', nhưng tài liệu chứa từ '**cope**' lại không liên quan đến chủ đề '**cop**', lỗi này phát sinh là do trong tiếng Anh, ta có khái niệm 1 từ có đa nghĩa.
  * Khi áp dụng, cần thực nghiệm trc hiệu quả của stemming trên tập dữ liệu nào đó trước khi áp dụng vào thực tế.

## 2.2. Tần số từ (TF-IDF):
* Tần số từ có 2 độ đo:
  * Tần số từ (term frequency): số lần xuất hiện của 1 từ trog tài liệu.
    * Sử dụng tần số xuất hiện để chỉ độ quan trọng tương đối của từ trog tài liệu.
    * Nếu 1 từ xuất hiện thường xuyên trong văn bản thì văn bản có liên hệ với chủ đề mà từ biểu diễn.
  * Tần số tài liệu (document frequency): số tài liệu trong dữ liệu mà chứa 1 từ xác định.
* TF-IDF (term frequency - inverse document frequency) cho biết độ quan trọng của 1 từ đối vs 1 tài liệu trog dữ liệu.
* Công thức:
  
  <center>

  <mark>**$tf*idf(t, d, D) = tf(t, d) * idf(t, D)$**</mark>

  </center>

  *Trong đó:*
    * ***$tf(t, d)$**: là tần số xuất hiện của từ $t$ trong tài liệu $d$*
    * ***$idf(t, D) = log\frac{|D|}{\left \lceil \{ d \in D:t \in d\} \right \rceil}$**, **$|D|$** là tổng số tài liệu **$d$** trong dữ liệu chứa từ **$t$***

### 2.2.1. Thể hiện tài liệu văn bản:
* Gọi $D$ là một tập tài liệu $\{d_1, d_2,...d_N\}$
* $V = \{t_1, t_2,...,t_{|v|}\}$ là tập các thuật ngữ phân biệt trong tài liệu, trong đó $t_i$ là một thuật ngữ, $|V|$ là kích thước
* Một trong số $w_{ij} > 0$ được gán cho mỗi thuật ngử $t_i$ của tài liệu $d_j$ thuộc $D$ xác định mức quan trọng của $t_i$ trong tài liệu $d_j$. Thuật ngữ không xuất hiện trong $d_j$, $w_{ij} = 0$
* Vì vậy mỗi tài liệu $d_j$ dc thể hiện dưới dạng vector: $d_j = (w_{1j}, w_{2j},...,w_{|v|j})$
  Ví dụ:

  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116719349_610370806284356_6493450568691978869_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=pL4bujfkV9EAX_5NzC8&_nc_ht=scontent-hkg4-1.xx&oh=d066895f96d10f3a6fc72139a12fc77b&oe=5F4882A6)

### 2.2.2. Mô hình luận lí:
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116088421_753907355421496_3989809230688868882_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=104&_nc_ohc=bUd0mXN6IkEAX_KH-WR&oh=76bb22579698b45559475a918028b6a9&oe=5F4A6FBE&ig_cache_key=MjM2NDY5ODQwODA3Mjc5NDg0Ng%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116430962_232135571208520_6446782332640458018_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=104&_nc_ohc=lEo6mGYnJKoAX-7loAW&oh=01a242da7fee745b62a8228924e455ae&oe=5F4C796F&ig_cache_key=MjM2NDY5ODY3MzgzMjQzODUxMA%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116336730_1365974543600767_7701837212941197310_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=107&_nc_ohc=RGJXj6oW3OUAX_bxyIC&oh=45ae9f774632c42cf005124e5e513cda&oe=5F4B6E20&ig_cache_key=MjM2NDY5OTA2NDM2MzkxNjk1Mw%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116671131_291224008636493_8731590516001491515_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=105&_nc_ohc=olwIZhTqRsgAX8kI72X&oh=c176ca53564c9ff15a5ce5c1be96f70a&oe=5F4D0543&ig_cache_key=MjM2NDY5OTM4ODA0NjgzMTkzNg%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116209386_1214678568866302_8338124336004784919_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=110&_nc_ohc=TuUdQgrAdaEAX9_Eu5B&oh=000b9c5b35bae0b42def97feaad7efb1&oe=5F4CA084&ig_cache_key=MjM2NDY5OTYxOTIwMzM2MDUxNQ%3D%3D.2)

### 2.2.3. Mô hình không gian vector:
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/115968997_290995568848307_5792326245074708167_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=111&_nc_ohc=Wfpqq3LvcrgAX-ULr8A&oh=4b32c7fa939bade513cd129f60a9623f&oe=5F4C21C2&ig_cache_key=MjM2NDcwMjk2NzczNDM4NDAwOA%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116265996_286804502416729_6198761169416129967_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=101&_nc_ohc=O81nuOSRepQAX_dJtpf&oh=87164602996337d74f9432e33d1540a8&oe=5F4C75C1&ig_cache_key=MjM2NDcxMDczNzUxNDcyOTY2NQ%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116243127_1043449992777647_6483648179904883354_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=111&_nc_ohc=puO1aQsB2OUAX_vpEbh&oh=d54300b1df61f5f3d9b03ae28852ec60&oe=5F4B6349&ig_cache_key=MjM2NDcxMjIxODY3NDU3MDI5Mg%3D%3D.2)
![](https://scontent.cdninstagram.com/v/t51.2885-15/e15/s640x640/116871827_1006266849819532_6301431451021533482_n.jpg?_nc_ht=scontent.cdninstagram.com&_nc_cat=104&_nc_ohc=8IeFyiAdnooAX95mdXi&oh=957484e129756bda008cabedc98379f3&oe=5F4B9692&ig_cache_key=MjM2NDcxMzk1MjU0OTM1MDc0Nw%3D%3D.2)

# 3. Chỉ mục đảo:
* Cho 1 tập tài liệu $D = \{d_1, d_2,..., d_N\}$ mỗi tài liệu có một **ID** duy nhất.
* Chỉ mục đảo gồm 2 bộ phận:
  * Ngữ vựng **V** chứa mọi từ phân biệt trong tài liệu văn bản
  * Với từ phân biệt $t_i$ danh sách đảo các **posting**
* Chỉ mục đão giúp cho việc tìm kiếm nhanh hơn.

## 3.1. Posting:
* Posting lưu **ID** (kí hiệu $id_i$) của tài liệu $d_i$ chứa từ $t_i$ và những thông tin khác về $t_i$ trong $d_i$ tùy ứng dụng.
  Ví dụ:

    <center>

    <mark>**$<id_i, f_ij, [o_1, o_2,...,o_{|f_{ij}|}]>$**</mark>
    
    </center>

    *Trong đó*:
    * $id_i$ là **ID** của văn bản $d_i$ chứa từ $t_i$
    * $f_i$ là tần số của $t_i$ trong $d_i$
    * $o_k$ là vị trí của $t_i$ trong $d_i$
* Posting của 1 từ dc sắp xếp theo thứ tự tăng dần của **ID** và **offset** trong mỗi posting cũng vậy.
* Ví dụ:
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116343214_287840262467367_8218942928147230212_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=qikytg2waakAX8P0UnN&_nc_ht=scontent-hkg4-1.xx&oh=357ec2ced97b6a4d2ab05b18d36ad71a&oe=5F4832A0)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116100254_2670839053131497_8724830792905561722_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=gnuaKaIte2UAX-jFKEC&_nc_ht=scontent-hkg4-1.xx&oh=e301b4571f6886f75c6c04bc0fcebe79&oe=5F45829C)

# 4. Đánh giá các độ đo:
* Giả sử sau câu truy vấn ng dùng, thuật toán trả ra cho chúng ta 50 tài liệu từ 100 tài liệu có trong database, nhưng bằng sức người thì thực chất trong 50 tài liệu này chỉ có 10 tài liệu là thực sự liên quan đến câu truy vấn người dùng mà thôi.
* Độ chính xác (precision): $p(i) = \frac{s_i}{i} = \frac{10}{50}$
* Độ chính xác trung bình:
  ![](https://scontent.fhan3-2.fna.fbcdn.net/v/t1.15752-9/116162885_293260955090551_3137827625613761092_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=fd7pp6RxX-YAX-qf85a&_nc_ht=scontent.fhan3-2.fna&oh=2700ef21d7dfeff8e3ea2e7fa709cce8&oe=5F491857)
  Ví dụ:
  ![](https://scontent.fhan3-2.fna.fbcdn.net/v/t1.15752-9/116084788_571410326889542_3369409673809925997_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=5PStVrK7w5EAX_TLhVZ&_nc_ht=scontent.fhan3-2.fna&oh=0ea73f26d901c8a4f267688dd649d7d2&oe=5F49BDCA)
* Độ phủ (recall): $r(i) = \frac{s_i}{|D_q|} = \frac{10}{100}$
* Độ đo F-score: $F(i) = \frac{2p(i)r(i)}{p(i) + r(i)}$

# 5. Các tạc vụ khai thác phổ biến:
## 5.1. Phân lớp:
* Giả sử có một đống tài liệu, hỏi từng tài liệu trong đống này thuộc lớp nào như lớp Văn hóa, thể thao, kiến thức,...
* Ứng dụng phổ biến hiện này là dùng để phân biệt xem một tin tức liệu có phải là tin fake hay ko.

### 5.1.1. Các bước thực hiện phân lớp:
![](https://scontent.fvca1-2.fna.fbcdn.net/v/t1.15752-9/116564968_324284172278262_5543106471978377014_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=Eitr7lRa9DcAX9p5uTC&_nc_ht=scontent.fvca1-2.fna&oh=cd5bf95db0e604af7327e21648710288&oe=5F47EA00)

* Thục hiện trọng số hóa tài liệu, có nhiều phương pháp thực hiện trọng số hóa tài liệu, nhưng giới hạn trong đây ta sẽ sử dụng phương pháp **TF-IDF**. Nhìn ở hình trên, mỗi record là 1 vector trọng số, trong đó cột **Class** là cột dùng để gán nhãn cho tài liệu đó thuộc phân lớp gì &rarr; Vậy tức hình trên là tập **training**

### 5.1.2. Thuật toán KNN:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116251580_629045521082944_6565799383372870096_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=fdH_7jD8HdYAX8i-ZjT&_nc_oc=AQnvzVYOfYBELVpiJunm4IuzfAc5A3lH7DV1xqgvkiohetyOzgZJHf25OcqCJkCOQjQ&_nc_ht=scontent-hkg4-1.xx&oh=fa970c6ca539fe2221a4d927526ad72a&oe=5F4B41A8)
* Cho những phần tử mang nhãn là **A** và những phần tử mang nhãn là **B**, hỏi phần tử xanh lá này sẽ thuộc vào nhãn nào?
* Nhìn trong vòng tròn xanh lá ta khoanh lại, ta thấy trong vùng đó có 2 phần tử là **B** và 1 phần tử là **A**, thì khả năng cao phần tử xanh lá này là **B**.
* Vậy câu hỏi đặt ra ở đây là "**K bao nhiêu là đủ?**" &rarr; Câu hỏi này rất khó trả lời.

#### 5.1.2.1. Các bước thực hiện thuật toán KNN:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116780616_318671522608126_6916738263958084777_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=xnmFp6WmSAwAX_L4Ws_&_nc_ht=scontent-hkg4-1.xx&oh=0368ba6d6eb64cd88c62b26215af3e4d&oe=5F4AF714)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116123853_713776962812403_6614747838751884979_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=1XQasBD5mE8AX-hjvWK&_nc_ht=scontent-hkg4-1.xx&oh=2c4edbe8234e98c117d63e15796de436&oe=5F484DBA)

## 5.2. Gom nhóm (clustering):
### 5.2.1. Thuật toán K-means:
* Các bước thực hiện: 
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116721003_624142018514503_8206762269709283042_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=lsKmjW_oRbAAX_3OWS8&_nc_ht=scontent-hkg4-1.xx&oh=5e27307b5fa7fbe75fdfde4c6b7117f5&oe=5F4B2B41)

* Ví dụ:
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116042196_769053623867777_5395538478266043850_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=rI4GiQZC2vMAX93Bo-B&_nc_ht=scontent-hkg4-1.xx&oh=8136532fed0c5684bcc611075f775ba2&oe=5F4AB0B0)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116581066_725958517977811_6872174947635494392_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=cDIMvtAdXdMAX9Eja6Z&_nc_ht=scontent-hkg4-1.xx&oh=99d0b261b9469c181ba00eacf4354d60&oe=5F482DFF)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116326856_282734829494709_3462235253442849804_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=I9voHoMq_JMAX9peCF2&_nc_ht=scontent-hkg4-1.xx&oh=44edf9c8dc35b0bb2769dd88e4eec663&oe=5F4A1FD1)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116220484_625185071457175_4242340915564082092_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=ogDQhArwvpcAX84nSBf&_nc_ht=scontent-hkg4-1.xx&oh=5c3aa35827771403e5da1e11016518ec&oe=5F4A2F0D)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116443028_886753285185040_211638937257919994_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=9BUgXvgyd7sAX_l6Vxa&_nc_ht=scontent-hkg4-1.xx&oh=2773097e17822f97680b3939e59b7e16&oe=5F4B1B49)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116042887_209961167087784_498730310143179762_n.png?_nc_cat=101&_nc_sid=b96e70&_nc_ohc=o8JJuu-g3fwAX_8q6Fo&_nc_ht=scontent-hkg4-1.xx&oh=724c0e694d74d1971ae8764d7af5ad5c&oe=5F4A8B16)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116358244_321954239155569_2094208411172407004_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=w405DPtxPm0AX8UC364&_nc_ht=scontent-hkg4-1.xx&oh=6ef0091dfa78b1362d6f13531c408e5b&oe=5F4991DF)
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116639249_321779745625321_1961570898758948172_n.png?_nc_cat=102&_nc_sid=b96e70&_nc_ohc=VZyqr8PuOukAX80xgdX&_nc_ht=scontent-hkg4-1.xx&oh=43a40c9a0f4713910e58bc62d4b23208&oe=5F47BFFF)

# 2. Khai thác cấu trúc web:
## 2.1. Các thuật toán áp dụng trong khai thác cấu trúc web:
* Có 2 thuật toàn dc áp dụng chính trong khai thác cấu trúc web:
  1. HITS (Hypertext-Induced Topic Search)
  2. Thuật toán xếp hạng trang (Page rank)

## 2.2. Các loại tính trung tâm:
* Có 3 loại phổ biến:
  1. Tính trung tâm bậc (degree centrality)
  2. Tính trung tâm gần (closeness centrality)
  3. Tính trung tâm trung gian (betweeness centrality)
  
  **&rarr;** Mỗi loại đều dc xem xét trên cả 2 đồ thị có hướng và vô hướng

### 2.2.1. Tính trung tâm bậc (degree centrality):
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116280870_286079619162562_3306514105414269313_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=yoNRD-0XVO4AX-pY7rA&_nc_ht=scontent-hkg4-1.xx&oh=1bf579dafba15f58b03ffb06ced6741e&oe=5F49A339)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116132831_288979055500228_275127454468561726_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=xaoBs6XA84AAX9Gupo-&_nc_ht=scontent-hkg4-1.xx&oh=6b6d757e77278ea7ec9c2971ad4abcfe&oe=5F4CB752)
  Xét ví dụ trên, ta có đỉnh 0 do là đồ thị vô hướng nên có bậc là 3, toàn đồ thị này có 11 đỉnh, nên $C_D(0) = \frac{3}{11 - 1} = 0.3$

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116246052_2157348937742527_5949988431409895888_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=zn9MOcuoQPsAX80JLB5&_nc_oc=AQnIV9pXK4dWHYEPa4hOyoUjPHhE_Omeaxo6bCaq0gZxyWtu9_Qh-njfMWW3ViZCkF8&_nc_ht=scontent-hkg4-1.xx&oh=85fb066d528dc9c81994a7013a63afb3&oe=5F4A7525)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116133766_2760994550892275_6596161782560589206_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=BH8Da75edBgAX95_itI&_nc_ht=scontent-hkg4-1.xx&oh=9b7002e771447723a797c10285f1694c&oe=5F49B144)
Xét ví dụ trên, giả sử ta tính trung tâm của đỉnh 11, thì đỉnh 11 này ta có 3 liên kết ngoài và toàn bộ đồ thị có 8 đỉnh, nên $C_D(11) = \frac{3}{8 - 1} = \frac{3}{7}$

### 2.2.2. Trung tâm gần (closeness centrality):
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116487769_2655312181453255_8689836949881557903_n.png?_nc_cat=101&_nc_sid=b96e70&_nc_ohc=IsP_CFl8abwAX-4B25K&_nc_ht=scontent-hkg4-1.xx&oh=40855382677935166d69555e0ce3929a&oe=5F4927BA)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116018581_295775888309208_4567003340321799048_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=4U5kzwCFfEQAX_YJpwm&_nc_ht=scontent-hkg4-1.xx&oh=60a38c1f69dfbfa3bd22825a456cb322&oe=5F4AAB5D)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116153317_708468393267313_6527378055536656289_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=XsvuWqVurooAX_6dQrb&_nc_ht=scontent-hkg4-1.xx&oh=0af4b4f6a1d5d48c6739b64c48623f6c&oe=5F4BFE7F)
công thức là n - 1 chia cho tổng khoảng cách, $C_C(i)$ càng lớn thì càng tốt
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116133766_2760994550892275_6596161782560589206_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=BH8Da75edBgAX95_itI&_nc_ht=scontent-hkg4-1.xx&oh=9b7002e771447723a797c10285f1694c&oe=5F49B144)
Giả sử ta sẽ tính cho đỉnh 11, ta có 8 đỉnh, ta lần lượt có các khoảng cách ngắn nhất từ đỉnh 11 đến các đỉnh khác như sau:
* 11 &rarr; 2 = 1
* 11 &rarr; 9 = 1
* 11 &rarr; 10 = 1
* Các đỉnh còn lại ko có đường đi nên mặc định là 0
  Nên $C_C(11) = \frac{8 - 1}{3} = \frac{7}{3}$

Giả sử bây giờ ta tính cho đỉnh thứ 5, ta lần lượt có các khoảng cách ngắn nhất từ 5 cho đến các đỉnh khác như sau:
* 5 &rarr; 2 = 2
* 5 &rarr; 10 = 2
* 5 &rarr; 9 = 2
* 5 &rarr; 11 = 1
  Nên $C_C(5) = \frac{8 - 1}{7} = \frac{7}{7} = 1$
  
### 2.2.3. Trung tâm trung gian (betweeness centrality):
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116922078_757852351694869_6040196617746881033_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=zNDA-34QHtUAX--IvXn&_nc_ht=scontent-hkg4-1.xx&oh=9cb370a85414cdb170bc3959ecb073f5&oe=5F4A5BBF)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116582781_738666076896216_1019730947301002233_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=2r2mq8n0avsAX9LHouq&_nc_ht=scontent-hkg4-1.xx&oh=3050d81889f9bd21405871e15f76fbe4&oe=5F4C5E01)
*Lưu ý công thức trên dc gọi là công thức chưa chuẩn hóa*
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/115990205_311060026976776_1441454358650553186_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=kaYmaCk_-qEAX9exzuW&_nc_ht=scontent-hkg4-1.xx&oh=9bed10bdf01041b3dc1da3868c794f18&oe=5F4BAB6D)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116794702_618713078776718_9166005596147392353_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=Sw-5RPJwGwUAX-j4aeq&_nc_ht=scontent-hkg4-1.xx&oh=d0d9344f06e5dbddc9740e6db85e266a&oe=5F4AF0A7)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116403615_747772426038460_995561345664427166_n.png?_nc_cat=111&_nc_sid=b96e70&_nc_ohc=XmpudVIrFF0AX_t6ojf&_nc_ht=scontent-hkg4-1.xx&oh=bb5390cac62965e9007630e9d98ec4b0&oe=5F4A8A7E)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116133766_2760994550892275_6596161782560589206_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=BH8Da75edBgAX95_itI&_nc_ht=scontent-hkg4-1.xx&oh=9b7002e771447723a797c10285f1694c&oe=5F49B144)
Giả sử tính cho đỉnh 11, ta lần lượt tính các cặp đỉnh đường đi ngắn nhất trong đồ thị mà 11 là đỉnh trung gian, ta có các cặp sau: 
***Cần lưu ý 1 điều là khi áp dụng công thức chưa chuẩn hóa, những đường đi của các cặp điểm mà ko đi qua đỉnh 11 sẽ dc đưa xuống mẫu, còn lại thì sẽ dc đưa lên tử***
  1. Trước tiên ta cần tính cho công thức chưa chuẩn hóa trc
      * Những cặp đỉnh ko đi qua đỉnh 11
        * 3 &rarr; 8, 3 &rarr; 9, 3 &rarr; 10, 5 &rarr; 2, 5 &rarr; 9, 5 &rarr; 10, 7 &rarr; 2, 7 &rarr; 8, 7 &rarr; 9 *(lưu ý đường đi từ 7 đến 9 có 2 con đường là 7 &rarr; 8 &rarr; 9 và 7 &rarr; 8 &rarr; 11 &rarr; 9, nhưng ở đây ta chọn đường 7 &rarr; 8 &rarr; 9, tức ta chọn đường ngắn nhất mà ko đi qua 11)*, 7 &rarr; 10, 8 &rarr; 9 => 11 đường đi
      * Những cặp đỉnh đi qua đỉnh 11
        * 5 &rarr; 2, 5 &rarr; 9, 5 &rarr; 10, 7 &rarr; 2, 7 &rarr; 10 => 5 đường đi
      
      => $C_B(11) = \frac{5}{11}$ **(1)**
  2. Áp dụng **(1)** vào công thức đã chuẩn hóa với trên đồ thị tổng cộng có 8 điểm ta dc:
    $C_B(11) = \frac{5/11}{(8 - 1)(8 - 2)}$

## 2.3. Tính uy tín:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116795155_640153253524070_5464471495312814749_n.png?_nc_cat=108&_nc_sid=b96e70&_nc_ohc=XlELz1N5DXAAX_oprrM&_nc_ht=scontent-hkg4-1.xx&oh=3115fbde42209e7418f0ee54957e9813&oe=5F4D58FE)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116227533_353030152363093_1745638527571906746_n.png?_nc_cat=102&_nc_sid=b96e70&_nc_ohc=AM2aPf16VjsAX--OegK&_nc_ht=scontent-hkg4-1.xx&oh=f67e57212da0315882eab4788038a7e8&oe=5F4EF6F8)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116437938_3433331873373214_1917832005874771181_n.png?_nc_cat=111&_nc_sid=b96e70&_nc_ohc=vQEnBhk_mvYAX_u2E9z&_nc_ht=scontent-hkg4-1.xx&oh=624d4b21323f6b2dd6dbec613101f9b7&oe=5F4E5BF4)

### 2.3.1. Tính uy tín bậc:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117213346_2712378629089449_5597919235298515241_n.png?_nc_cat=101&_nc_sid=b96e70&_nc_ohc=lwV6Jxy06HYAX-2xmlu&_nc_ht=scontent-hkg4-1.xx&oh=484b4ab4dcc9df0de58d548588c5d10e&oe=5F4EC1E3)
  Ví dụ:
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116294825_1147247305786723_4313201682037702433_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=fA2M1ZXWYAgAX9Tnb2W&_nc_ht=scontent-hkg4-1.xx&oh=61c65460a0afb40467bbb4901ac87d73&oe=5F509F7E)
  * Tính độ uy tín bậc cho đỉnh 11, nhận thấy đỉnh 11 có 2 đỉnh khác hướng đến và đồ thị có 8 đỉnh nên: 
  $P_D(11) = \frac{2}{8 - 1} = \frac{2}{7}$
  * Tính độ uy tín bậc cho đỉnh 5, nhận thấy đỉnh 5 có 0 đỉnh khác hướng đến và đồ thị có 8 đỉnh nên: 
  $P_D(5) = \frac{0}{8 - 1} = 0$

### 2.3.2. Tính uy tín xấp xỉ:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116247625_210117960439662_4093661172845002906_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=mBwn2TEzW_gAX8OXi0d&_nc_ht=scontent-hkg4-1.xx&oh=9f016e3dd49019d4de32ec4177fd2e6c&oe=5F4EB802)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117145218_293549578645243_2997824318573952834_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=13leCcIShhsAX_pO9xO&_nc_ht=scontent-hkg4-1.xx&oh=bee356c248c65ed5b6abd56dbf3e0c79&oe=5F50C210)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116584490_282503113011197_32874038755050112_n.png?_nc_cat=101&_nc_sid=b96e70&_nc_ohc=ttdatVh0D30AX8a8OMo&_nc_ht=scontent-hkg4-1.xx&oh=2b143fb537726675ce8b4489232d8df7&oe=5F4D374A)
  Ví dụ:
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116341676_1480365392151714_2923565834357284312_n.png?_nc_cat=111&_nc_sid=b96e70&_nc_ohc=x1tZGLHflYIAX88TzsU&_nc_ht=scontent-hkg4-1.xx&oh=c9517739d69a79c46dcd6b6baf6d3f7f&oe=5F4D3A5F)

  * Tính uy tín xấp xỉ cho đỉnh 11 (lưu ý áp dụng công thức chưa chuẩn hóa)"
    1. Tính khoảng cách của các đỉnh đi dc đến đỉnh 11 (tử):
      * 5 &rarr; 11 = 1
      * 7 &rarr; 11 = 1
    2. Tính số lượng đỉnh đi dc đến đỉnh 11, chỉ bao gồm 5 và 7 nên = 2 (mẫu)
    3. $P_P(11) = \frac{2}{2} = 1$
  * Tính uy tín xấp xỉ cho đỉnh 9 (lưu ý áp dụng công thức chưa chuẩn hóa)"
    1. Tính khoảng cách của các đỉnh đi dc đến đỉnh 9 (tử):
      * 3 &rarr; 9 = 2
      * 5 &rarr; 9 = 2
      * 7 &rarr; 9 = 2
      * 8 &rarr; 9 = 1
      * 11 &rarr; 9 = 1
    2. Tính số lượng đỉnh đi dc đến đỉnh 11, chỉ bao gồm 3, 5, 7, 8 và 11 nên = 5 (mẫu)
    3. $P_P(5) = \frac{2 + 2 + 2 + 1 + 1}{5} = \frac{8}{5}$

### 2.3.3. Tính uy tín hạng:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116252700_4135389686502195_5381096842275039023_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=GCmefuHwlEcAX-fVrwg&_nc_ht=scontent-hkg4-1.xx&oh=7bafcfce4fbdc206fd5bdc50dc496498&oe=5F4F30AE)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116367973_2719102874857774_4609259369239006594_n.png?_nc_cat=102&_nc_sid=b96e70&_nc_ohc=648kMMolHlYAX8TJ0oS&_nc_ht=scontent-hkg4-1.xx&oh=9e45a04985eb2dba228d44a6aff00269&oe=5F4FFB62)
  Ví dụ:
  ![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116210981_3320647897999505_9145227404838613164_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=1ZCe9v7dM6EAX9unSi0&_nc_ht=scontent-hkg4-1.xx&oh=d14308894a39b5f6643a77365d7ed330&oe=5F4D42D7)
  * Tính uy tín hạng cho đỉnh 11, để tính dc uy tính hạng của đỉnh 11 thì ta phải có dc uy tín hạng của các đỉnh hướng tới 11 là các đỉnh 5 và 7

## 2.4. Đồng trích dẫn:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116134307_298310848268013_3201227231402478728_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=yc6YglNSbPAAX8FG-P4&_nc_ht=scontent-hkg4-1.xx&oh=944009210742e5c3001523683a368e78&oe=5F500931)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117035011_604800817127727_5101934379757298256_n.png?_nc_cat=111&_nc_sid=b96e70&_nc_ohc=ZfuBJBkFQLIAX_dKcwa&_nc_oc=AQms76liA4R1UTaKilp3EnpAeiSIU9Qmw4uaExbnVcuJI2mfMXbsT-LO1cohDf1HtOY&_nc_ht=scontent-hkg4-1.xx&oh=fc83f199f895e85b42489ea941fe36c1&oe=5F50BEF3)

## 2.5. Mối nối danh mục:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116588791_2408012509498676_6455370757613897018_n.png?_nc_cat=101&_nc_sid=b96e70&_nc_ohc=zNWIYvEwAPwAX_ADD6I&_nc_ht=scontent-hkg4-1.xx&oh=cf3c4b96c50edd9b269c1edab2a8d31c&oe=5F504590)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116786121_941106219692160_5243482800336208162_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=sOlu_c2oxcIAX_T2MUf&_nc_ht=scontent-hkg4-1.xx&oh=dad1d7ec19ee10b49edf1d8159109e19&oe=5F4E168F)

## 2.6. PageRank:
![](https://scontent.fvca1-2.fna.fbcdn.net/v/t1.15752-9/116326856_1558383507699710_4721139845803507510_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=uLDAVavAR8kAX_0rxJQ&_nc_ht=scontent.fvca1-2.fna&oh=5006d7bfa7c1e0e7bd3ec4f6a38489c1&oe=5F4EAAA4)
![](https://scontent.fvca1-1.fna.fbcdn.net/v/t1.15752-9/116582086_2987425918046396_2517891344328420799_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=SPi60Vah8hsAX-O9ZUo&_nc_ht=scontent.fvca1-1.fna&oh=00a9bb8c5d4e9043356521927b821f42&oe=5F51A355)

## 2.7. HITS:
![](https://scontent.fsgn8-1.fna.fbcdn.net/v/t1.15752-9/116710346_3268492259914447_3414754660190579179_n.png?_nc_cat=108&_nc_sid=b96e70&_nc_ohc=EgA2oWS_69QAX-HLIOv&_nc_ht=scontent.fsgn8-1.fna&oh=c6daee8767e6f9e8fb6896d9dc78dbf5&oe=5F50E367)
![](https://scontent.fvca1-1.fna.fbcdn.net/v/t1.15752-9/116905634_3182186145194894_1004985069267522809_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=BVB-A0EIX9QAX8BnfVM&_nc_ht=scontent.fvca1-1.fna&oh=2832a6649bf9b4c7917fa2116fb15ab0&oe=5F51B54B)
![](https://scontent.fsgn8-1.fna.fbcdn.net/v/t1.15752-9/116950089_2359307844376938_4203293692580103136_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=iuwZr3fKY04AX_7glfB&_nc_ht=scontent.fsgn8-1.fna&oh=35a3dd2a177fc7d8b2fa7613bbd90b74&oe=5F4F3F09)
![](https://scontent.fvca1-1.fna.fbcdn.net/v/t1.15752-9/117117045_765524734251493_8591166292681519163_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=Zz_8nRFwHboAX-mobBx&_nc_ht=scontent.fvca1-1.fna&oh=ca43ae8424dfb8216e05f0f53aaa5b16&oe=5F4F06F6)
![](https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.15752-9/116192077_633085114079418_3094249769867285215_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=WiblqNJiSs0AX94Vjds&_nc_ht=scontent.fsgn4-1.fna&oh=eb6d86813b1f08c587c14eb53cf5ff73&oe=5F50CF02)
![](https://scontent.fsgn8-1.fna.fbcdn.net/v/t1.15752-9/116852250_612996749351816_1968239430454204185_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=TRIwRiXNkj4AX-pKjtB&_nc_ht=scontent.fsgn8-1.fna&oh=384f48cfb58be5b1ec8dbb0350cb4705&oe=5F4DD5A0)
![](https://scontent.fvca1-1.fna.fbcdn.net/v/t1.15752-9/116837636_348562049636438_5887066817819099636_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=YMQktL0vxjAAX_E3dmY&_nc_ht=scontent.fvca1-1.fna&oh=34d4c324d207d2f9aa976ab28cf3093c&oe=5F508A6C)

<center>

# BÀI TẬP

</center>
#1. Khai thác nội dung Web:

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116712610_306285323917466_6232954586538146614_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=BQqSnFAVjo4AX_woIp7&_nc_ht=scontent-hkg4-1.xx&oh=ee1f680dcd11aec28dc90ef03b6b164d&oe=5F4DF789)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116852237_4859245304101068_144567665305025098_n.png?_nc_cat=102&_nc_sid=b96e70&_nc_ohc=B-_D_5TONzoAX97P2ia&_nc_ht=scontent-hkg4-1.xx&oh=9b7f7cb08f027cb3e9ecef9a0ded3e32&oe=5F4B9109)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116465841_289683318978916_4435609895513580786_n.png?_nc_cat=106&_nc_sid=b96e70&_nc_ohc=87mXDgN8xX4AX_y1BPY&_nc_ht=scontent-hkg4-1.xx&oh=745ac2e434312bcc6e9fb53e864e1822&oe=5F4D5F2B)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116851702_1161931637497069_8381316197712365468_n.png?_nc_cat=100&_nc_sid=b96e70&_nc_ohc=7U9ysUxdX1AAX_fhtAX&_nc_ht=scontent-hkg4-1.xx&oh=236834615a0c9ddcbbacfef2208c8691&oe=5F4F8C09)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116300788_295578178176974_3582380562970953367_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=pUCOCXuv5zwAX9NvXyT&_nc_oc=AQn8VI5RBEY8jDO5egARxVNK6tjFzSNAQTY92pHZKNA__hPlWEW4TV3hdjOlyfvFpZs&_nc_ht=scontent-hkg4-1.xx&oh=8eb774c87a32eef6e1676ed74f360488&oe=5F4F8C73)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116263822_1161535294213304_7182342562035359398_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=WwZve3-BdCAAX95HXWs&_nc_ht=scontent-hkg4-1.xx&oh=fc4dec972cf16bcd4a45c6f4a8eff653&oe=5F4DE993)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117263532_3135445376550670_2362393818397782577_n.png?_nc_cat=107&_nc_sid=b96e70&_nc_ohc=2RJhLT8wd1YAX_MJUTO&_nc_ht=scontent-hkg4-1.xx&oh=9eb77296cb32240412078f9e9520ee25&oe=5F4F8520)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116265234_1397761773744224_7687361123131318303_n.png?_nc_cat=100&_nc_sid=b96e70&_nc_ohc=vNHt81R-BscAX_Xfxun&_nc_oc=AQnUtpGmHk9nNFU938FTlCI-oGgfHiY2D9FOmbvu-s1udSnbuNrUu0lXoLfQDSGyDHc&_nc_ht=scontent-hkg4-1.xx&oh=81536e2b52e65e5cb066818d32eb0b4b&oe=5F4CD204)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116261054_294856028271764_4071261942495240483_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=xnl6oLyMnO4AX-VSVhm&_nc_ht=scontent-hkg4-1.xx&oh=1cea70d2faf2d2be1ff93775e1e1e9f5&oe=5F4E4C3C)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116255604_535284980529083_209525632509580795_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=wgRPsrDYSRMAX970ZPh&_nc_ht=scontent-hkg4-1.xx&oh=ba16f9ef1ce3cad3e1da94c2943e3cc0&oe=5F50D97B)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117105859_2883780968533463_7838729485916908736_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=AJot-cREOOMAX9QZngX&_nc_ht=scontent-hkg4-1.xx&oh=5a5444918c8e9a7dba3c4557d1fa269d&oe=5F5217DA)
Xem lại ví dụ demo phần lí thuyết
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116793110_641774029796379_2763556001570060626_n.png?_nc_cat=108&_nc_sid=b96e70&_nc_ohc=M8P1bKK3xfcAX_dp7Zu&_nc_ht=scontent-hkg4-1.xx&oh=b447ccb18afea78cd33c748e9eae470b&oe=5F51E92D)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117061537_229030418268528_1642496516297566792_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=e7UZq1YcdPEAX8_32J1&_nc_ht=scontent-hkg4-1.xx&oh=a2861406bc923b40414eb1c35130d9f2&oe=5F52078E)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116835706_677321839663538_8919365199221008032_n.png?_nc_cat=111&_nc_sid=b96e70&_nc_ohc=NI9CYamaHnIAX-3dtli&_nc_ht=scontent-hkg4-1.xx&oh=d6a863b1e46c9dffa9f50308fff4ae6b&oe=5F50250C)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117101905_3042259499226957_1385982499540727576_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=NZrPFiwwL4EAX9wF7Jp&_nc_ht=scontent-hkg4-1.xx&oh=14967f13f1cd3a7f9a88c0fb85c6638b&oe=5F519A51)
# 2. Khai thác cấu trúc web:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116729784_709110089638142_6687192882282270924_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=6kFFuk1hO0gAX9lQ65T&_nc_ht=scontent-hkg4-1.xx&oh=5a34e48e66f102fdb6adaa1e078d8568&oe=5F50BD96)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116909451_423608321890726_6030517468788176260_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=NoOR5Z2KhuIAX81I3gT&_nc_ht=scontent-hkg4-1.xx&oh=60209271e0ff50b9e5fedf74023db2e9&oe=5F4E89CF)
* Hình a: đồ thị có 7 đỉnh
  * đỉnh 1 = $\frac{2}{7 - 1} = 0.33$
  * đỉnh 2 = $\frac{3}{7 - 1} = 0.5$
  * mấy thằng khác tự tính
* Hình b: đồ thị có 8 đỉnh
  * đỉnh 1 = $\frac{2}{8 - 1} = 0.285$
  * đỉnh 2 = $\frac{1}{8 - 1} = 0.142$
  * mấy thằng khác tự tính

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117044404_2427779920852681_753040826151143213_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=oHUSl-yVn4QAX_8fA3i&_nc_ht=scontent-hkg4-1.xx&oh=04c6c6197292341d66ad0bb456d6d28e&oe=5F523252)
* Hình a: đồ thị có 7 đỉnh:
  * đỉnh 1 có các cặp (đỉnh tới, chi phí) như sau: (2, 1), (3, 1), (4, 2), (5, 2), (6, 3), (7, 3) = $\frac{7 - 1}{1 + 1 + 2 + 2 + 3 + 3} = 0.5$
  * mấy khác tự tính nha con trai
* Hình b: đồ thị có 8 đỉnh (liên kết ra nha mấy ba) (giá trị tính ra càng nhỏ càng tốt):
  * đỉnh 1 có các cặp (đỉnh tới, chi phí) như sau: (2, 1), (3, 2), (4, 1), (6, 3), (7, 4), (8, 3) = $\frac{8 - 1}{1 + 2 + 1 + 3 + 4 + 3} = 0.5$
  
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117185246_2363782410583261_5588827283674614898_n.png?_nc_cat=109&_nc_sid=b96e70&_nc_ohc=VfXsL0voSGAAX842lns&_nc_ht=scontent-hkg4-1.xx&oh=c0457836548d3cf829441ce96704a821&oe=5F4E71CC)
* Hình a: đồ thị có 7 đỉnh:
  * đỉnh 1: 
    * Các cặp đường đi phải qua đỉnh 1 là 0
    &rarr; = 0
  * đỉnh 2: y chang 1 = 0
  * đỉnh 3:
    * Các cặp đường đi ngắn nhất phải qua 3 là: (1, 4)
    * Các cặp đường đi ngắn nhất là: (1, 2), (1, 4), (1, 5), (1, 6), (1, 7), (2, 4), (2, 5), (2, 6), (2, 7), (4, 5), (4, 6), (4, 7), (5, 6), (5, 7), (6, 7)
    &rarr; = $2\frac{1/15}{(7 - 1)(7 - 2)} = 0.004$

* Hình b: đồ thị có 8 đỉnh:
  * đỉnh 1 = 0 do 1 toàn liên kết ngoài nên ko đỉnh nào đi dc tới 1 hết
  * đỉnh 2:
    * Các cặp đường đi ngắn nhất phải qua 2 là: (3, 4), (8, 3), (8, 4)
    * Các cặp đường đi ngắn nhất là: (1, 3), (1, 4), (1, 6), (1, 7), (1, 8), (3, 4), (3, 6), (3, 7), (3, 8), (4, 3), (4, 6), (4, 7), (4, 8), (5, 3), (5, 4), (5, 6), (5, 7), (5, 8), (7, 6), (8, 3), (8, 4), (8, 6), (8, 7)
    &rarr; = $\frac{3/23}{(8 - 1)(8 - 2)} = 0.003$

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116879850_326918341957720_7029340056602321610_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=fP0aV0rKOHgAX-EETVq&_nc_ht=scontent-hkg4-1.xx&oh=f766fa53cd71d6c2d7be0badb68b74f7&oe=5F521C50)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117301597_829164127614295_8974796898524883756_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=dCcnSyy5T4sAX96FOQx&_nc_ht=scontent-hkg4-1.xx&oh=20e32c9fd79c1485bdeb3d5dc94bbf99&oe=5F511DF1)
* ***Tính uy tín thì chỉ quan tâm liên kết vào thôi***
* Hình e: có 8 đỉnh
  * Đỉnh 1 = $\frac{0}{8 - 1} = 0$ (do ko có thằng nào vào 1 cả)
  * Đỉnh 2 = $\frac{2}{8 - 1} = 0.285$
  * tự tính nha
* Hình f: có 8 đỉnh
  * Đỉnh 2 = $\frac{3}{8 - 1} = 0.428$

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116985304_322687899095901_693792139688118293_n.png?_nc_cat=103&_nc_sid=b96e70&_nc_ohc=0IQzXI-qzHUAX8HVZ8U&_nc_ht=scontent-hkg4-1.xx&oh=52d02e26328962479b3dd3721294d4ed&oe=5F530AFE)
* Hình e:
  * Đỉnh 1: 
    B1. Tính tổng khoảng cách những thằng đi đến đỉnh 1 dc:
      ko có thằng nào nên đáp số là 0
  
  * Đỉnh 2: có 8 đỉnh
    B1. Tính tổng khoảng cách những thằng đi đến đỉnh 2 dc theo format (đỉnh, chi phí): (1, 1), (3, 2), (4, 3), (5, 4), (8, 1) &rarr; có 5 đỉnh đi đến 2 dc
    B2. Áp dụng công thức dc:
      $P_P(2) = \frac{5/(8 - 1)}{(1 + 2 + 3 + 4 + 1)/(5)} = 0.3245$

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116329363_506802466790675_2432800087062708412_n.png?_nc_cat=110&_nc_sid=b96e70&_nc_ohc=Is632DCd6wkAX_fwkUq&_nc_ht=scontent-hkg4-1.xx&oh=08ec19a271c8b48de1aff24d82663e75&oe=5F530968)
***Nếu đề bài ko đề cập đến giá trị khởi tạo thì ta mặc định là 0.1***
* Hình e:
  * Đỉnh 1 = 0 (do ko ai trỏ vô nó)
  * Đỉnh 2 = có đỉnh 1 và 8 trỏ zo nên = 0.1 + 0.1 = 0.2

![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116877475_289941722100291_4696155268011252344_n.png?_nc_cat=108&_nc_sid=b96e70&_nc_ohc=4xr19HCkT0EAX9xT4Jw&_nc_ht=scontent-hkg4-1.xx&oh=1ad886f0045b5466185288c6b4b4c8a5&oe=5F5269CF)
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116811857_2952835524839304_3393254682895908063_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=LLi9-1k4edQAX8JXJYb&_nc_ht=scontent-hkg4-1.xx&oh=990986a46027c7ff599a78986cda7be7&oe=5F508926)
**Câu a**:
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/117160999_779175205959698_1425666451860484078_n.png?_nc_cat=105&_nc_sid=b96e70&_nc_ohc=lHns5Mq_H48AX8iWBoG&_nc_ht=scontent-hkg4-1.xx&oh=34357afffb3ea5b37d50b284b5e8c353&oe=5F4F9DD9)
**Câu b**:
* Hub là liên kết đi ra, Authorities là liên kết đi vào*
* Tính hub thì cộng tất cả Authorities liên kết đến
* Tính Authorities thì cộng tất cả Hub liên kết đến
* Tính vòng 2 thì lấy data vòng 1 tính
![](https://scontent-hkg4-1.xx.fbcdn.net/v/t1.15752-9/116428157_345692386447146_1264295020770118853_n.png?_nc_cat=104&_nc_sid=b96e70&_nc_ohc=NZnnSGanrjMAX9HRuOS&_nc_ht=scontent-hkg4-1.xx&oh=2ae50b6810532cfb6a61e5c7da9c4d08&oe=5F527EE8)

