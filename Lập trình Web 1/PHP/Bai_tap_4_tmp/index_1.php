<!DOCTYPE html>
<html lang="en">

<body>
    <?php 
        if (isset($_POST['nSubmit'])){
            $firstName = $_POST['nFirstName'];
            $lastName = $_POST['nLastName'];
        }
    ?>
    <form action="index_2.php" method="post">
        First Name: <input type="text" name="nFirstName" id="iFirstName"><br><br>
        Last Name: <input type="text" name="nLastName" id="iLastName"><br><br>
        <input type="submit" value="Submit" name="nSubmit">
        <input type="button" value="Reset" onclick="formatForm()">

        <script>
            function formatForm() {
                document.getElementById("iFirstName").value = "";
                document.getElementById("iLastName").value = "";
            }
        </script>
    </form>
</body>

</html>