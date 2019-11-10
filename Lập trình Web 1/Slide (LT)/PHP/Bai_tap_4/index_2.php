<?php
$numberA = $_POST["nFirstNumber"];
$numberB = $_POST["nSecondNumber"];
$operator = $_POST["operator"];
$nameCal = "";
$Result = "";
$erroInfo = "";

    if($operator == "vAdd"){
        $nameCal = "Cộng";
        $Result = $numberA + $numberB;
    }

    if($operator == "vSub"){
        $nameCal = "Trừ";
        $Result = $numberA - $numberB;
    }

    if($operator == "vMul"){
        $nameCal = "Nhân";
        $Result = $numberA * $numberB;
    }

    if($operator == "vDiv"){
        if($numberB <= 0){
            $nameCal = "Chia";
            $erroInfo = "* Số thứ hai > 0";
        }else{
            $nameCal = "Chia";
            $Result = $numberA / $numberB;
        }
    }
?>

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
                    <span>Chọn phép tính:&nbsp;&nbsp;&nbsp;&nbsp;<?php echo $nameCal;?></span>
                    <br /><br />
                    <span class="lb_textbox">Số thứ nhất: &nbsp;&nbsp;</span>
                    <input type="text" name="nFirstNumber" id="iFirstNumber" value="<?php echo $numberA; ?>">
                    <br /><br />
                    <span class="lb_textbox">&nbsp;&nbsp;Số thứ hai: &nbsp;&nbsp;</span>
                    <input type="text" name="nSecondNumber" id="iSecondNumber" value="<?php echo $numberB; ?>">
                    <span style="color:red"><?php echo $erroInfo;?></span>
                    <br /><br />
                    <span class="lb_textbox">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kết quả: &nbsp;&nbsp;</span>
                    <input type="text" value="<?php echo $Result; ?>">
                </form>
                <br />
                <a href="javascript:window.history.back(-1);">Quay về trang trước</a>
            </div>
        </div>
    </div>
</body>

</html>