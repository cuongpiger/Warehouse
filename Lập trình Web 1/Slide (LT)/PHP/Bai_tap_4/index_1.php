<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="style.css" type="text/css">
    <script src="../js/jquery.min.js"></script>
    <script src="../js/popper.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/script.js"></script>
    <title>Bai Tap 4</title>
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="col-xl-12">
                <h1 class="title_header">PHÉP TÍNH TRÊN HAI SỐ</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <form action="index_2.php" method="post">
                    <span>Chọn phép tính:&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <input type="radio" name="operator" value="vAdd" checked="checked" />
                    <label>&nbsp;Cộng&nbsp;&nbsp;&nbsp;</label>

                    <input type="radio" name="operator" value="vSub" />
                    <label>&nbsp;Trừ&nbsp;&nbsp;&nbsp;</label>

                    <input type="radio" name="operator" value="vMul" />
                    <label>&nbsp;Nhân&nbsp;&nbsp;&nbsp;</label>

                    <input type="radio" name="operator" value="vDiv" />
                    <label>&nbsp;Chia&nbsp;&nbsp;&nbsp;</label>

                    <br /><br />
                    <span class="lb_textbox">Số thứ nhất: &nbsp;&nbsp;</span>
                    <input type="text" name="nFirstNumber" id="iFirstNumber">
                    <br /><br />
                    <span class="lb_textbox">&nbsp;&nbsp;Số thứ hai: &nbsp;&nbsp;</span>
                    <input type="text" name="nSecondNumber" id="iSecondNumber">
                    <br /><br />
                    <input type="submit" name="nSmCalculate" id="iSmCalculate" value="Tính">
                </form>
            </div>
        </div>
    </div>
</body>

</html>