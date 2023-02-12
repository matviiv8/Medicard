function ShowPassword() {
	var passwordTextBox = document.getElementById('password');
	var confirmPasswordTextBox = document.getElementById('confirmPassword');
	if (confirmPasswordTextBox == null) {
		if (passwordTextBox.getAttribute('type') == 'text') {
			passwordTextBox.type = 'password';
		}
		else {
			passwordTextBox.type = 'text';
		}
	}
	else {
		if (passwordTextBox.getAttribute('type') == 'text' && confirmPasswordTextBox.getAttribute('type') == 'text') {
			passwordTextBox.type = 'password';
			confirmPasswordTextBox.type = 'password';
		}
		else {
			passwordTextBox.type = 'text';
			confirmPasswordTextBox.type = 'text';
		}
	}
}