<?php
    /* Database credentials. Assuming you are running MySQL
    server with default setting (user 'root' with no password) */
    // Connect to the MySQL database
    $servername = "mysql-arjardin.alwaysdata.net";
    $username = "arjardin";
    $password = "arjardin@2023";
    $dbname = "arjardin_db";

    // Create connection
    $conn = new mysqli($servername, $username, $password, $dbname);
    // Check connection
    if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
    }

    $sql = "SELECT * FROM plante";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo $row["id"]."-".$row["nom"]."-".$row["famille"]."-".$row["pays"]."-".$row["description"]."#";
    }
    } else {
    echo "0 results";
    }
    $conn->close();
?>