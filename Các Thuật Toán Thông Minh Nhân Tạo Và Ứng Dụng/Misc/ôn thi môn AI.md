# Độ ưu tiên của các phép toán
> Theo thứ tự từ <mark>TRÁI</mark> qua <mark>PHẢI</mark> độ ưu tiên <mark>GIẢM DẦN</mark>
> **&not;**, **&#8896;**, **&#8897;**, **&#8658;**, **&#8660;**
>
> Các phép:
> * $a$ &#8658; $b$ &#8801; &not;$a$ &#8897; $b$
> * $a$ &#8660; $b$ &#8801; $(a$ &#8658; $b)$ &#8896; $(b$  &#8658; $a)$


# 3. Máy học
## 3.1. ILA
> **Bước 1**: Tách bảng dữ liệu thành những bảng con mà mỗi bảng có các giá trị ở trường <mark>**KẾT LUẬN**</mark> là như nhau.
> **Bước 2**: Xét từng bảng, chọn giá trị nào chỉ xuất hiện ở bảng này mà không xuất hiện ở các bảng còn lại.
> **Bước 3**: Chọn ra giá trị mà xuất hiện nhiều nhất, sau khi xét các giá trị đó ta tiến hành bỏ đi những dòng chứa giá trị đó đi.

##### VÍ DỤ:
Cho bảng dữ liệu như sau cần được dùng để học: sự quyết định của khách hàng sẽ quyết định mua hay ko mua một món hàng nào đó sẽ phụ thuộc vào 3 yếu tố lần lượt là: <mark>**Kích cỡ**</mark>, <mark>**Màu sắc**</mark>, <mark>**Hình dáng**</mark>. Người ta tiến hình khảo sát trên <mark>**7 khách hàng**</mark> thì ta được bảng bên dưới. Nhiệm vụ là chúng ta cần đưa ra các luật để biết trong trường hợp nào khách hàng sẽ quyết định mua và trong trường hợp nào khách hàng sẽ quyết định rằng không mua.
![](https://b-f25-zpg.zdn.vn/3017225826781945031/32921c5c7fa986f7dfb8.jpg)
<!---->
**Bước 1**: Dựa vào trường <mark>**Quyết định**</mark> ta thu được 2 bảng như sau:
**<center>Bảng 1: bao gồm các giá trị là <mark>MUA</mark></center>**
![](https://b-f24-zpg.zdn.vn/4800464034598043227/4e44c83ebccb45951cda.jpg)
**<center>Bảng 2: bao gồm các giá trị là <mark>KO MUA</mark></center>**
![](https://b.f10.group.zp.zdn.vn/4137983516459272182/601654f42101d85f8110.jpg)

**Bước 2.0**: Xét <mark>**Bảng 1**</mark> có các giá trị **{'Vừa', 'Xanh dương', 'Xanh lá', 'Hộp', 'Cầu'}** xuất hiện ở bảng này mà ko xuất hiện ở <mark>**Bảng 2**</mark>.
![](https://b-f25-zpg.zdn.vn/7208445326921758631/3242c2578ea277fc2eb3.jpg)

**Bước 3.0**: Giá trị <mark>**Xanh lá**</mark> và <mark>**Cầu**</mark> đều xuất hiện 2 lần, ở đây ta chọn <mark>**Xanh lá**</mark>. Tại đây ta sẽ sinh ra một luật: ***Nếu màu sắc là Xanh lá thì sẽ quyết định Mua***: <mark>***if Màu sắc = Xanh lá then Quyết định = Mua***</mark>, bỏ những dòng chứa giá trị <mark>**Xanh lá**</mark>.
![](https://b-f25-zpg.zdn.vn/5245672285898534471/67f9263b62ce9b90c2df.jpg)

Bây giờ chỉ còn 4 giá trị là **{'Vừa', 'Xanh dương', 
'Hộp', 'Cầu'}**, ta chọn giá trị <mark>**Vừa**</mark> *(Chọn dòng này ta sẽ bỏ qua được nhiều giá trị để giảm chi phí tính toán xuống)*.
![](https://b.f9.group.zp.zdn.vn/7288531545450227619/c598033f45cabc94e5db.jpg)

Đến lúc này thì chỉ còn giá trị là <mark>**Cầu**</mark>, cuối cùng ta sẽ thu được các luật như sau cho <mark>**Bảng 1**</mark>.
![](https://b-f26-zpg.zdn.vn/4900048136962082572/9821de2f9eda67843ecb.jpg)

**Bước 2.1 - 3.1**: Khôi phục lại <mark>**Bảng 1**</mark>, tiến hành xét trên <mark>**Bảng 2**</mark> chọn ra những giá trị mà ko xuất hiện ở <mark>**Bảng 1**</mark>, ta thu được giá trị <mark>**Nón**</mark> xuất hiện 2 lần, sau đó tiền hành viết luật cho nó.
![](https://b-f25-zpg.zdn.vn/2010973628931099845/91b216cd5538ac66f529.jpg)

Bây giờ bảng sẽ còn như sau:
![](https://b-f24-zpg.zdn.vn/6817415249432638823/5ed0d0b08c45751b2c54.jpg)

Đến lúc này do ko còn giá trị nào mà chỉ xuất hiện trên <mark>**Bảng 2**</mark> mà ko xuất hiện trên <mark>**Bảng 1**</mark>, cho nên ta tiến hành tăng số giá trị mà ta sẽ xét lên thành 2, ta có cặp <mark>**('Lớn', 'Đỏ')**</mark> và ta tiến hành xây dựng luật cho nó và xóa bỏ dòng này => hết bảng => xong, đéo làm j nữa hết.
![](https://b-f24-zpg.zdn.vn/2022809797945475850/20f7ef4db2b84be612a9.jpg)


## 3.2. ID3
> **Ý TƯỞNG**
> ![](https://b.f9.group.zp.zdn.vn/390455767930827877/4c23b5acac5855060c49.jpg)
### 3.2.1. Entropy (độ hỗn loạn)
> * $S$ là các mẫu huấn luyện
> * $p$ là tỉ lệ các mẫu dương trong $S$
> * <mark>**$H = -p.log_{_2}(p) - (1 - p).log_{_2}(1 - p)$**</mark>

> ##### Các bước thực hiện
> **Bước 1**: Chọn ra thuộc tính có <mark>Entropy thấp nhất</mark>, sau đó đưa vào cây.
> **Bước 2**: Bắt đầu xây dựng các cây con từ nhánh này, sau đó quay lại **Bước 1**.

##### VÍ DỤ
Cho bảng dữ liệu như sau:
![](https://b-f24-zpg.zdn.vn/7452501547016429788/f3bb362c50d8a986f0c9.jpg)

**Bước 1**: Tính Entropy cho từng thuộc tính:
* **Outlook**
  Có các giá trị là **{'Rain', 'Overcast', 'Sunny'}** lần lượt ở trường <mark>**PlayTennis**</mark> ta thu được các kết quả tương ứng như sau *(+ là Yes, - là No)*, **{(3+, 2-), (4+, 0-), (2+, 3-)}** với các giá trị Entropy tương ứng là **{0.971, 0, 0.971}**.

  ![](https://b-f25-zpg.zdn.vn/5354792299222697078/1c39c406b9f240ac19e3.jpg)
  Đây là cách tính Entropy cho từng giá trị:
  ![](https://b-f25-zpg.zdn.vn/2037015085831369030/0c17db88a07c5922006d.jpg)
  Tiếp theo tính <mark>**$AE$** ***(Entropy trung bình)*** **= $\sum_{v \epsilon Value(A)}(p_{_v}H_{_Av})$**</mark>
  ![](https://b.f9.group.zp.zdn.vn/3571472909660070852/31cf1c4741b3b8ede1a2.jpg)

* **Temperature, Humidity, Wind** tương tự là:
  ![](https://b.f10.group.zp.zdn.vn/6029846698702348359/213dc7ea981e6140380f.jpg)
  ![](https://b.f9.group.zp.zdn.vn/5317483040379523938/c2d81ad74223bb7de232.jpg)

Từ đây ta thấy thuộc tính **Outlook** có <mark>**$AE$**</mark> thấp nhất nên ta chọn **Outlook**, thu được cây như sau:
![](https://b-f24-zpg.zdn.vn/2420846411623589552/9ffee4d6b5224c7c1533.jpg)

**Bước 2**: Xét trên từng nhánh **{'Rain', 'Overcast', 'Sunny'}**, ta tính các Entropy
![](https://b.f9.photo.talk.zdn.vn/6995410756235989100/1f9e6638c2cc3b9262dd.jpg) 
ta thu được các <mark>**$AE$**</mark> như sau:

Nếu hết thuộc tính mà ko còn trường nào để chọn dc nữa, thì ta chọn giá trị xuất hiện nh nhất cho nó

## 3.3. Naive Bayes
> * Định lí Bayes:
> **$P(C_{_i}|X) = \frac{P(X|C_{{_i}}).P(C_{_i})}{P(X)}$**
> * Dự đoán X thuộc về lớp $C_{_i}$ khi và chỉ khi $P(C_{_i}|X)$ là cao nhất trong số $P(C_{_m}|X)$ của tất cả $m$ lớp.
> * Thực tế, tính toán này đòi hỏi nhiều xác suất khởi tạo và tốn chi phí thực thi đáng kể.

<ins>**Ví dụ**</ins>
Cần xác định các đối tượng có mua máy tính hay không, có là Yes, ko là No
![](https://b.f4.photo.talk.zdn.vn/2396933780338061424/dbae6b0c4bfcb2a2ebed.jpg)
***<center>Giải</center>***

> * Từ yêu cầu đề bài ta có mẫu $X$ như sau:
> $X = (age $ &le; $ 30, income = medium, student = yes, creditRating = fair)$
> $P(yes|X) = p(yes).p(X|yes)$ (nhìn cột cuối cùng)
> ....................$= \frac{9}{14}.p(age $ &le; $ 30|yes).p(income = medium|yes).p(student = yes|yes).p(creditRating = fair|yes)$
> ....................$= \frac{9}{14}. \frac{2}{9}.\frac{4}{9}.\frac{6}{9}.\frac{6}{9} = 0.028$
> $P(no|X) = p(no).p(X|no)$ (thực hiện tương tư như $P(yes|X)$) $= 0.007$
> Vì $P(yes|X) > P(no|X)$ nên mẫu $X$ phân lớp là yes

<ins>**Vấn đề khi có giá trị 0 chèn vào**</ins>
Giả sử khi tính $P$ mà một trong các $p$ có giá trị 0, thì ko thể tiếp tục so sánh => có 1 cách giải quyết khác, tổng giá trị phân biệt ở mẫu, và tử luôn cộng thêm 1
Ví dụ:
> $P(yes|X) = p(yes).p(X|yes)$ (nhìn cột cuối cùng)
> ....................$= \frac{9}{14}.p(age $ &le; $ 30|yes).p(income = medium|yes).p(student = yes|yes).p(creditRating = fair|yes)$
> ....................$= \frac{9}{14}. \frac{2}{9}.\frac{0}{9}.\frac{6}{9}.\frac{6}{9}$
> ....................$= \frac{9 + 1}{14 + 2}. \frac{2 + 1}{9 + 3}.\frac{0 + 1}{9 + 3}.\frac{6 + 1}{9 + 2}.\frac{6 + 1}{9 + 2} = something$