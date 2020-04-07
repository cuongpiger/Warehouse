**Lưu ý**: *được tự tìm hiểu và dịch từ cuốn Web Data Mining 2nd Edition - Exploring Hyperlinks Contents and Usage Data bởi [Manh Cuong](https://www.facebook.com/cuongpigerr/)*

# 2. Luật kết hợp (Association Rules) và mẫu tuần tự (Sequential Patterns)
&nbsp;&nbsp;&nbsp;&nbsp;Luật kết hợp là một phần rất quan trọng của tính thường xuyên trong dữ liệu. Khai thác luật kết hợp là một trong những công việc cơ bản của khai thác dữ liệu. Có thể nói nó là mô hình quan trọng nhất được phát minh và nghiên cứu rộng rãi bởi cộng đồng cơ sở dữ liệu và khai thác dữ liệu. Mục tiêu của nó là tìm tất cả các quan hệ cùng xảy ra (**co-occurrence relationships**) hay còn được gọi là các mối kết hợp (**associations**) giữa các tập dữ liệu. Kể từ khi nó được giới thiệu vào năm 1993 bợi Agrawal et al, nó đã thu hút được rất nhiều sự chú ý. Nhiều thuật toán có hiệu suất cao, phần mở rộng và ứng dụng hiệu quả đã được báo cáo. Một trong những ứng dụng cơ bản của khai thác luật kết hợp là bài toán phân tích dữ liệu ***Market basket***, nhằm mục đích là khám phá ra cách mà các mặt hàng được mua bởi khách hàng trong một siêu thị (hay một cửa hàng) kết hợp với nhau. Một ví dụ cho luật kết hợp là:

**<center>Cheese &rarr; Beer [support = 10%, confidence = 80%]</center>**

&nbsp;&nbsp;&nbsp;&nbsp;Luật cho rằng sẽ có 10% khách hàng sẽ mua $Cheese$ và $Beer$ cùng nhau, và theo đó những người mua $Cheese$ thì sẽ có 80% là họ cũng sẽ mua kèm thêm $Beer$. ***support*** và ***confidence*** là 2 độ đo trong luật, chúng ta sẽ tìm hiểu nó sau.

&nbsp;&nbsp;&nbsp;&nbsp;Khai thác mẫu trên thực tế nó khá là chung chung và có thể được sử dụng được trong nhiều ứng dụng. Ví dụ, trong ngữ cảnh là Web là tài liệu văn bản, có thể được sử dụng để tìm các mối quan hệ cùng xuất hiện của các từ và Web usage pattern (mẫu biệu thị những thói quen sử dụng Web) mà chúng ta cũng sẽ tìm hiểu nó ở phần sau.

&nbsp;&nbsp;&nbsp;&nbsp;Khai thác luật kết hợp sẽ không xem xét đến trình tự mà các món hàng được mua. Mà thay vào đó khai thác mẫu tuần tự sẽ làm việc đó. Một ví dụ cho khai thác mẫu tuần tự là 5% khách hàng sẽ mua giường trước, sau đó đó họ sẽ mua nệm và cuối cùng là gối. Những mặt hàng này không được mua trong cùng một thời điểm mà là mua từng cái một. Những mẫu như vậy sẽ rất hữu ích trong việc khai thác thói quen sử dụng Web để phân tích các luồng click chuột được lưu trong nhật kí máy chủ. Chúng cũng rất hữu ích trong việt tìm kiếm ngôn ngữ hay các mẫu ngôn ngữ trong các văn bản ngôn ngữ tự nhiên.

## 2.1. Các khái niệm cơ bản trong Luật kết hợp
&nbsp;&nbsp;&nbsp;&nbsp;Bài toán khai thác luật kết hợp có thể được nêu ra như sau: đặt $I = \{ i_{1}, i_{2}, ..., i_{m} \}$ là tập chứa các mặt hàng (***itemSet***), đặt $T = ( t_{1}, t_{2}, ..., t_{n} )$ là tập chứa các giao dịch (***transSet***) được lưu trong database, theo đó mỗi giao dịch $t_{i}$ là một tập hợp các ***item*** sao cho $t_{i}$ là tập con của $I$ ($t_{i}$ &sube; $I$). Một luật kết hợp là một hàm có dạng:

> **<center>X &rarr; Y, where X &sub; I, Y &sub; I and X &cap; Y = &empty;</center>**
> * **X** (or **Y**) là tập các item, được gọi là ***itemSet***.

##### VÍ DỤ 1
&nbsp;&nbsp;&nbsp;&nbsp;Chúng ta muốn phân tích cách mà các mặt hàng được bán trong một siêu thị có liên quan như thế nào với nhau. Với $I$ là tập các mặt hàng (***item***) được bán trong siêu thị. Một giao dịch (***transaction***) đơn giản là tập các mặt hàng trong giỏ được mua bởi khách hàng. Ví dụ, một giao dịch sẽ có dạng: $\{ Beef, Chicken, Cheese \}$, điều này có nghĩa là khách hàng đã mua 3 mặt hàng trong giỏ, bao gồm $Beef$, $Chicken$ và $Cheese$. Một luật kết hợp có thể là: $Beef$, $Chicken$ &rarr; $Cheese$, trong đó $\{$$Beef$, $Chicken$$\}$ là tập **X** và $\{Cheese\}$ là tập **Y**. Thông thường cho đơn giản, người ta thường bỏ đi các dấu '$\{$' và '$\}$' khi ta viết các giao dịch cũng như luật.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Một giao dịch $t_{i}$ &isin; $T$ được cho là chứa một tập hạng mục (***itemSet***) $X$ khi $X$ là tập con của $t_{i}$ (ta cũng có thể nói rằng tập hạng mục $X$ bao lấy $t_{i}$). Đếm hỗ trợ (***support count***) của $X$ trong $T$ (kí hiệu $X.count$) là số lượng giao dịch nằm trong $T$ được chứa trong $X$. Luật được tính dựa trên 2 độ đo là ***support*** và ***confidence***

* ***support***: support của luật $X$ &rarr; $Y$ là phần trăm số giao dịch trong $T$ có chứa $(X$ &cup; $Y)$. support được định nghĩa là độ thường xuyên mà luật có thể áp dụng được trong tập giao dịch $T$. Đặt $n$ là số lượng giao dịch của tập $T$. support của luật $X$ &rarr; $Y$ sẽ được tính theo công thức sau:
  
  > **<center>support = $\frac{(X \cup Y).count}{n}$&nbsp;&nbsp;&nbsp;&nbsp;*(1)*</center>**
  
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;support là một độ đo hữu ích bởi vì nó thấp, luật có thể được sinh ra do có cơ hội. Hơn nữa, trong môi trường kinh doanh, một luật có thể bao phủ rất ít trường hợp (tức giao dịch) và nó sẽ không hữu ích bởi vì nó không có ý nghĩa trong kinh doanh nếu đi theo luật đó (không mạng lại lợi nhuận).

* ***confidence***: confidence của luật $X$ &rarr; $Y$ là phần trăm số giao dịch $T$ mà chứ cả 2 tập $X$ và $Y$. Được tính theo công thức:
  
  > **<center>confidence = $\frac{(X \cup Y).count}{X.count}$&nbsp;&nbsp;&nbsp;&nbsp;*(2)*</center>**

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;confidence được xác định là khả năng dự đoán được của luật. Nếu như confidence quá thấp, người ta không thể sinh ra hay dự đoán được $Y$ từ $X$. Một luật mà có khả năng dự đoán quá thấp sẽ bị hạn chế sử dụng.