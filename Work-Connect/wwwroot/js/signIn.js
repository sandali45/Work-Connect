﻿function togglePassword() {
    const passwordField = document.getElementById('password');
    const showPasswordText = document.querySelector('.show-password');

    if (passwordField.type === 'password') {
        passwordField.type = 'text';
        showPasswordText.textContent = 'Hide';
    } else {
        passwordField.type = 'password';
        showPasswordText.textContent = 'Show';
    }
}
