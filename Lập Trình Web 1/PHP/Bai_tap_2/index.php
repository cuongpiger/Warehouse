<!DOCTYPE html>
<html lang="en">

<body>
    <table border=1>
        <tr>
            <th>STT</th>
            <th>Tên sách</th>
            <th>Nội dung sách</th>
        </tr>


        <?php
        for ($i = 0; $i <= 100; $i++) {?>
        <tr>
            <td><?php echo $i; ?></td>
            <td><?php echo "Tên sách $i"; ?></td>
            <td><?php echo "Nội dung $i"; ?></td>
        </tr>
        <?php } ?>
    </table>
</body>

</html>