*Duong Manh Cuong*
*cuongpigerr@gmail.com*
*Dec-25-2019*

# 1. Cookies & Sessions
## 1.1. Cookies

<ins>**VÍ DỤ**</ins>
Ta vào trang Amazon, click vào thanh tìm kiếm và gõ "switch". Chúng ta thử click vào một mặt hàng nào đó (tại đây tôi sẽ click vào mặt hàng khoanh đỏ trong hình bên dưới).

![](https://b.f8.photo.talk.zdn.vn/3471601379999266659/ff56f188b70e4e50171f.jpg)

Và sau đó chọn thêm nó vào giỏ hàng.

![](https://b.f9.photo.talk.zdn.vn/1537941403100134534/11c05bd0de5627087e47.jpg)

Và bây giờ nó hiện lên một thông báo hỏi xem chúng ta có xác định mua hàng này không, ta chọn **CREATE LIST**.

![](https://b.f9.photo.talk.zdn.vn/7719429200456377549/25202d9baa1d53430a0c.jpg)

Và bây giờ, nếu ta có tắt đi trình duyệt và hôm sau mở lại và vào Amazon, chúng ta vẫn sẽ thấy item này nằm trong giỏ hàng.

Và khi Amazon đã gắn được Cookies vào máy tính cá nhân, điều đó có nghĩa rằng khi user đăng nhập vào một trang web nào khác sau đó, chẳng hạn như Facebook thì tức sau đó, Amazon đã biết user này là ai và đâu là những thứ mà user này muốn mua trên trang e-commerce của họ và từ đó Amazon sẽ cố gắng nhắc nhở cho user nhớ rằng "có vài thứ bạn muốn mua mà chưa mua" trên Amazon, hay còn gọi là **CHẠY QUẢNG CÁO**. Và đây là một trong những cách phổ biến mà ứng dụng quảng cáo ngày nay sử dụng.

Và tất cả các thứ trên, đều được thông qua <mark>***Cookies & Sessions***</mark>.

![](https://b.f7.photo.talk.zdn.vn/6092205103224397800/5c2bed5019d6e088b9c7.jpg)

<ins>**VẬY TÁC DỤNG CỦA COOKIES LÀ GÌ?**</ins>
> * Ngày nay, Cookies được sử dụng rộng rãi trên Internet để lưu lại các phiên duyệt web của user.
> * Ngoài ra còn giúp giảm thiểu các thao tác, hành động lặp đi lặp lại, hay không quá cần thiết của người dùng trên web (ví dụ như khi ta đăng nhập vào Facebook một lần, thì những lần sau chúng ta chỉ cần gho URL facebook.com là có thể đăng nhập ngay vào trang cá nhân mà không cần gõ lại account hay password).
> * Cookie cũng được dùng để lưu những thông tin tạm thời.
> * Tệp tin cookie sẽ được truyền từ server tới browser và được lưu trữ trên máy tính của bạn khi bạn truy cập vào ứng dụng.

<ins>**VẤN ĐỀ BẢO MẬT**</ins>
Do Cookies thường được sử dụng để quản lý trạng thái của người dùng (ví dụ trạng thái đăng nhập), do đó có thể có một số vấn đề liên quan đến bảo mật khi sử dụng Cookies. Ví dụ như Cookies lưu trạng thái đăng nhập của người dùng bị đánh cắp, hacker có thể dùng Cookies này để giả mạo làm người dùng và thực hiện tương tác với trang web mà không cần đăng nhập. Một số extension của trình duyệt cho phép share Cookies để những người dùng khác nhau cùng truy cập vào 1 tài khoản mà không cần biết thông tin truy cập như username và password.


## 1.2. Sessions
Có rất nhiều loại Cookies khác nhau nhưng những cái mà ta thấy được trên Chrome là những Cookies dùng để thiết lập và duy trì một **Session** (hay còn gọi là một ***PHIÊN LÀM VIỆC***).

<ins>**VẬY SESSION LÀ GÌ?**</ins>
> * Session là khoảng thời gian browser có thể tương tác với server.
> * Được lưu trên server.
> * Chứa dữ liệu từ user.
> * Session bắt đầu khi client gửi request đến server và kết thúc khi hết thời gian timeout (thời gian cho phép client có thể tương tác với server, (hãy nhớ về hệ thống portal của HCMUS mỗi khi đăng kí học phần, thời gian timeout là 10 phút, sau đó bắt đăng nhập lại)) hoặc khi bạn đăng xuất khỏi trang web đó. 
> * Do session lưu trên server, nên nếu sử dụng vô tội vạ với các hệ thống lớn số lượng client có thể lên đến hàng triệu thì sẽ đè nặng lên lên server phải lưu trữ nhiều, nên session thường chỉ lưu những thông tin đơn giản như thông tin đăng nhập, thông tin chi tiết giỏ hàng,...
> * Mỗi session sẽ được cấp một ID duy nhất trên mỗi phiên làm việc, ID này sẽ được thay đổi qua từng phiên làm việc khác nhau.

Vậy nên thông thường khi bạn đăng nhập vào một trang web, tức lúc này là Session của bạn đã được bắt đầu và cũng là lúc Cookies của bạn đã được tạo ra. Và bên trong Cookies của bạn sẽ chứa thông tin của bạn rằng: user này đã đăng nhập và xác thực thành công. Và từ đây, nếu bạn có tiếp tục duyệt web thì nó cũng sẽ không yêu cầu bạn đăng nhập lại lần nữa cho dù bạn có cố gắng truy cập lại vào chính trang đăng nhập bằng địa chỉ URL, bởi vì server luôn có thể kiểm tra các Cookies khả dụng mà bạn có trên chính browser của bạn và điều này giúp duy trì tính xác thực của bạn cho Session hiện tại cho tới khi bạn đăng xuất ra thì lúc này Session sẽ kết thúc và mọi Cookies liên quan trực tiếp đến Session này sẽ đều bị phá hủy.


## 1.3. Mô hình hoạt động
Như vậy, ví dụ trên đã cho ta hiểu sương sương về ***Cookies & Sessions*** là gì, cũng như ứng dụng của nó. Vậy khi ta nhìn nó dưới khía cạnh của một Web Development thì như thế nào?

Giả sử vào một ngày tôi truy cập vào trang Amazon.com, lúc này Browser của tôi sẽ tạo một Get Request và gửi đến server cuả Amazon **_(1)_**. Sau đó server sẽ hồi đáp lại (hay còn gọi là Response) request của tôi và sẽ tiến hành gửi các file HTML, CSS, Javascript cần thiết cho browser của tôi để tiến hành render ra trang Amazon **_(2)_**. Và giả sử bây giờ, tôi thêm một cái laptop vào giỏ hàng của tôi và điều nay tương đương với việc tôi đang thực hiện một cái Post Request, nói với server Amazon rằng là tôi đang muốn mua một cái Laptop **_(3)_**. Và sau đó, server Amazon sẽ tạo ra một cái Cookies chứa các tập dữ liệu về giao dịch của tôi rằng "User này muốn mua một cái laptop" và khi server tiến hành Response lại cho Post Request này (đã tiến hành ở bước (3)), cái Cookies được tạo ra sẽ được gửi theo cùng đồng thời nói cho Browser biết rằng "Hãy lưu cái Cookies này lại" **_(4)_**. Vậy nên nếu như bây giờ tôi tắt trang Amazon đi và vào một số trang khác như Facebook, Twitter hay bất cứ trang web nào khác và vào lại trang Amazon vào ngày hôm sau. Cái Cookies này vẫn còn nằm ở đó trong Browser của tôi do nó đã được Browser lưu lại rồi **_(5)_**. Và ngày hôm sau khi tôi cũng gửi một cái Get Request này đến server Amazon, cái Cookies của ngày hôm trước sẽ được đính kèm và gửi theo cùng để cho server có thể xác định được "tôi là ai", "tôi đã truy cập vào trang Amazon trước đây chưa" **_(6)_**. Và từ đây, tương đương Cookies đã được server tiếp nhận và tiến hành mở ra và biết được giao dịch này của bạn là gì, những gì bạn định mua,... Trong trường hợp này là chiếc laptop **_(7)_**. Sau đó server sẽ tiến hành Response lại bao gồm các file HTML, CSS, Javascript và cũng bao gồm luôn giỏ hàng của user với chiếc laptop mà hôm trước chúng ta xem đã được thêm sẵn vào **_(8)_**.

![](https://b.f6.photo.talk.zdn.vn/87796594043423019/05de46f02a71d32f8a60.jpg)


## 1.4. Điểm khác biệt giữa Cookies và Sessions
|Cookie|Session|
|-----------|-----------|
|Cookie được lưu trữ trên trình duyệt của người dùng.|Session không được lưu trữ trong trình duyệt của người dùng.|
| Dữ liệu cookie được lưu trữ ở phía máy khách.|Dữ liệu session được lưu trữ ở phía máy chủ.|
|Dữ liệu cookie dễ dàng sửa đổi khi chúng được lưu trữ ở phía khách hàng.|Dữ liệu session không dễ dàng sửa đổi vì chúng được lưu trữ ở phía máy chủ.|
|Dữ liệu cookie có sẵn trong trình duyệt của chúng ta đến khi hết hạn.|Dữ liệu session có sẵn cho trình duyệt chạy. Sau khi đóng trình duyệt sẽ mất thông tin session.|