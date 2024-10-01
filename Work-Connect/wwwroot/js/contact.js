function sendEmail() {
    const name = document.getElementById('name').value;
    const email = document.getElementById('email').value;
    const message = document.getElementById('message').value;

    const subject = `New Contact Form Submission from ${name}`;
    const body = `Name: ${name}%0AEmail: ${email}%0A%0AMessage:%0A${message}`;

    window.location.href = `mailto:onithesanya@gmail.com?subject=${subject}&body=${body}`;
}
