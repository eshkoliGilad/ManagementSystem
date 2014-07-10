<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8"></meta>
<script type="text/javascript">
            function redirect(){
                window.location = "../table.php"
            }
	function redirectMail(){
                window.location = "../mail.php"
            }
function invalidMail(){
alert('ערך אי-מייל לא חוקי, נסה שוב בהמשך');
}
       </script>
</head>
<meta name="apple-mobile-web-app-status-bar-style" content="white-translucent"/>
<body>
<link rel="stylesheet" href="style_mail.css" type="text/css" />
<?php
mb_internal_encoding('UTF-8');
function spamcheck($field) {
  // Sanitize e-mail address
  $field=filter_var($field, FILTER_SANITIZE_EMAIL);
  // Validate e-mail address
  if(filter_var($field, FILTER_VALIDATE_EMAIL)) {
    return TRUE;
  } else {
    return FALSE;
  }
}
?>

<h2 style="color:#000; text-align:center">&#1496;&#1493;&#1508;&#1505; &#1500;&#1513;&#1500;&#1497;&#1495;&#1514; &#1491;&#1493;&#1488;&#1512; &#1488;&#1500;&#1511;&#1496;&#1512;&#1493;&#1504;&#1497;</h2>
<br>
<?php
// display form if user has not clicked submit
if(isset($_POST["back"])) {
echo '<script type="text/javascript">redirect();</script>';
}
if (!isset($_POST["submit"])) {
  ?>
  <form dir="rtl" style="text-align:center" id="send" method="post" action="<?php echo $_SERVER["PHP_SELF"];?>">
  &#1502;&#1488;&#1514;: <input type="text" name="from"><br><br>
 &#1504;&#1493;&#1513;&#1488;: <input type="text" name="subject"><br><br>
  &#1492;&#1493;&#1491;&#1506;&#1492;:<textarea id="message" style="vertical-align: top" rows="10" cols="40" name="message"></textarea><br><br>
  <input type="submit" name="submit" value="שלח דואר">
  <input type="submit" name="back" value="חזרה">
  </form>
  <?php
} else {  // the user has submitted the form
  // Check if the "from" input field is filled out
  if (isset($_POST["from"])) {
    // Check if "from" email address is valid
    $mailcheck = spamcheck($_POST["from"]);
    if ($mailcheck==FALSE) {
      echo '<script type="text/javascript">invalidMail();</script>';
echo '<script type="text/javascript">redirectMail();</script>';
    } else {
      $from = $_POST["from"]; // sender
      $subject = $_POST["subject"];
      $message = $_POST["message"];
      // message lines should not exceed 70 characters (PHP rule), so wrap it
      $message = wordwrap($message, 70);
      // send mail
$headers1  = "MIME-Version: 1.0\r\n";
$headers1 .= "Content-type: text/html; charset=UTF-8\r\n";
$headers1 .= "From: ".$from."\r\n";


     $result= mail("gilades@post.jce.ac.il",'=?UTF-8?B?'.base64_encode($subject).'?=',$message,$headers1);
if($result)
{
 echo "<div align='center'>&#1502;&#1497;&#1497;&#1500; &#1504;&#1513;&#1500;&#1495; &#1489;&#1492;&#1510;&#1500;&#1495;&#1492;, &#1488;&#1504;&#1488; &#1492;&#1502;&#1514;&#1503;</div>";
sleep(5);
echo '<script type="text/javascript">redirect();</script>';
          

}
else
{
echo "<div align='center'>&#1488;&#1497;&#1512;&#1506;&#1492; &#1513;&#1490;&#1497;&#1488;&#1492; &#1489;&#1513;&#1500;&#1497;&#1495;&#1514; &#1492;&#1492;&#1493;&#1491;&#1506;&#1492;, &#1488;&#1504;&#1488; &#1492;&#1502;&#1514;&#1503; &#1493;&#1504;&#1505;&#1492; &#1513;&#1493;&#1489;</div>";
sleep(5);
echo '<script type="text/javascript">redirect();</script>';
}

    }
  }
}

	

?>

</body>
</html>