<!DOCTYPE html>
<html lang="en">

<body>
    <select>
        <?php $namHienTai = date("Y"); ?>
        <?php for ($i = $namHienTai; $i >= 1900; $i--) { ?>
                <option><?php echo $i; ?></option>
        <?php } ?>
    </select>
</body>

</html>