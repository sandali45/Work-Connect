// Toggle password visibility
const showPassword = document.querySelector('.show-password');
const passwordInput = document.getElementById('password');

showPassword.addEventListener('click', () => {
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);
    showPassword.textContent = type === 'password' ? 'Show' : 'Hide';
});