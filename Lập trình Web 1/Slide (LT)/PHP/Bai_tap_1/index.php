<!DOCTYPE html>
<html lang="en">

<body>
    <?php
        for ($i = 1; $i <= 100; $i++) {
            if ($i % 2 == 0) {
                echo "<b> $i </b>";
            }
            else {
                echo $i;
            }
        }
    ?>
</body>

</html>