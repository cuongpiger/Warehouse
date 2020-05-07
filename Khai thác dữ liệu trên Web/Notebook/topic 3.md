#1. Tính toán TF-IDF
* **TF**: dùng để đánh giá độ xuất hiện thường xuyên của một từ $t_{i}$ nào đó trong tài liệu $d_{j}$, độ đo $tf_{ij}$ được tính bằng số lần xuất hiện của từ $f_{ij}$ trong tài liệu, tức là số lần từ $t_{i}$ xuất hiện trong tài liệu $d_{j}$, chia cho từ có tần số xuất hiện nhiều nhất trong tài liệu $d_{j}$, ở đây kí hiệu là $max\{f_{1j}, f_{2j}, ..., f_{vj}\}$.
  > &nbsp;
  > $tf_{ij} = \frac{f_{ij}}{max\{f_{1j}, f_{2j}, ..., f_{vj}\}}$
  > &nbsp;
  * *Ví dụ*: Trong tài liệu số 1, có 3 từ $\{A, B, C\}$ với tần số xuất hiện lần lượt là $\{100, 10, 1000\}$, giả sử ta cần tính **tf** cho từ $A$ thì ta có: $tf_{A} = \frac{f_{A}}{max\{f_{A}, f_{B}, f_{C}\}} = \frac{100}{1000} = 0.1$.
* **IDF**: trước khi nói về độ đo **idf** thì trước tiên ta sẽ tìm hiểu độ đo **df** trước:
  * **DF**: là số tài liệu $d_{j}$ xuất hiện một từ $t_{i}$ nào đó.
    * *Ví dụ*: Chúng ta có $N$ tài liệu và $t_{i} = A$, vậy ta $df$ cần tính là trong $N$ tài liệu này, có bao nhiêu tài liệu chứa từ $A$.
    * *Công thức*:
      > &nbsp;
      > $df_{i} = \frac{f_{i}}{N}$
      > trong đó:
      > * **$df_{i}$**: là độ đo df của $t_{i}$
      > * **$df_{i}$**: số tài liệu có chứa từ $t_{i}$
      > * **$N$**: tổng số lượng tài liệu cần xét
      > &nbsp;
  * **IDF**:
    * *Công thức*:
      > &nbsp;
      > $idf_{i} = log_{10}(\frac{N}{df_{i}})$
      > &nbsp;
* **TF*IDF**: 
  * Cuối cùng sau khi tính được 2 độ đo **tf** và **idf** ta thu được công thức cuối cùng khi nhân **tf** cho **idf**:
      > &nbsp;
      > $w_{ij} = tf_{ij}*idf_{i}$
      > &nbsp;
  * *Ví dụ*:
    ![](https://f24-zpg.zdn.vn/5658569250632172634/508206a96f9d95c3cc8c.jpg)
#2. Câu truy vấn người dùng
* *Công thức*:
  >  &nbsp;
  > $w_{iq} = (0.5 + \frac{0.5*f_{iq}}{max\{f_{1q}, f_{2q},...,f_{vq}\}}) * log_{10}(\frac{N}{df_{i}})$
  > &nbsp;
  > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$= (0.5 + 0.5*tf_{iq})*idf_{i}$
  > &nbsp;
#3. Tìm tài liệu nào liên quan đền câu truy vấn người dùng:
* Sau khi có được một vector query (câu truy vấn người dùng) và tập hợp các vector của mỗi tài liệu. Thì bây giờ ta sẽ đi tìm tài liệu nào liên quan đến câu truy vấn người dùng, có rất nhiều cách đo, và một trong những cách đo là người ta đi tính góc hợp bởi 2 vector đó, góc **θ** càng nhỏ thì 2 tài liệu đó càng liên quan.
  ![](https://f27-zpg.zdn.vn/8644081088676717286/9f60e13c5008aa56f319.jpg)
* *Công thức*:
  > &nbsp;
  >![](https://f31-zpg.zdn.vn/1285490730783272885/93f29e051531ef6fb620.jpg)
  > &nbsp;
* Ví dụ: 
  ![](https://f31-zpg.zdn.vn/3925456826500504746/03e8b7e433d0c98e90c1.jpg)
  Dưới đây là cách tính $cosin(d_{j}, q)$ chi tiết:
    * Ta có tích vô hướng $<d_{j}*q> = (2*2 + 1*1 + 0*1 + 2*1 + 0*1 + 1*0 + 1*1 + 1*1) = 9$<br><br>
    * Độ dài vector $d_{j}$ là $||d_{j}|| = \sqrt{2^2 + 1^2 + 0^2 + 2^2 + 0^2 + 1^2 + 1^2 + 1^2} = \sqrt{12} ≈ 3.4641$<br><br>
    * Độ dài vector $q$ là $||q|| = \sqrt{2^2 + 1^2 + 1^2 + 1^2 + 1^2 + 0^2 + 1^2 + 1^2} = \sqrt{10} ≈ 3.1623$<br><br>
    * Vậy $cosin(d_{j}, q) = \frac{9}{3.4641*3.1623} ≈ 0.822$<br><br>

