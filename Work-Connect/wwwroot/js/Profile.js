// Function to display the selected cover photo
function displayCoverPhoto(input) {
    if (input.files && input.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById('cover-photo').src = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }
}

// Function to display the selected profile picture
function displayProfilePic(input) {
    if (input.files && input.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById('profile-picture').src = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }
}

// Open the experience modal
function openExperienceModal() {
    document.getElementById('experience-modal').style.display = 'block';
}

// Close the experience modal
function closeExperienceModal() {
    document.getElementById('experience-modal').style.display = 'none';
}

// Add a new experience
function addExperience() {
    // Get values from the form
    const jobTitle = document.getElementById('job-title').value;
    const companyName = document.getElementById('company-name').value;
    const startDate = document.getElementById('start-date').value;
    const endDate = document.getElementById('end-date').value || 'Present'; // Default to 'Present' if no end date
    const description = document.getElementById('experience-description').value; // Correct ID here

    // Check if all fields are correctly populated
    if (!jobTitle || !companyName || !description) {
        alert('Please fill in all the required fields.');
        return;
    }

    // Create a new div to hold the experience details
    const experienceDiv = document.createElement('div');
    experienceDiv.classList.add('experience-item');

    // Add the experience details to the div
    experienceDiv.innerHTML = `
      <strong>Job Title:</strong> ${jobTitle} <br>
      <strong>Company Name:</strong> ${companyName} <br>
      <strong>Period:</strong> ${startDate} - ${endDate} <br>
      <strong>Description:</strong> ${description} <br><br>
    `;

    // Append the new experience to the list of experiences
    const experienceList = document.getElementById('experience-list');
    experienceList.appendChild(experienceDiv);

    // Hide the placeholder text if it still exists
    const experiencePlaceholder = document.getElementById('experience-placeholder');
    if (experiencePlaceholder) {
        experiencePlaceholder.style.display = 'none';
    }

    // Clear form fields
    document.getElementById('experience-form').reset();

    // Close the modal
    closeExperienceModal();
}



// Function to open the Education modal
function openEducationModal() {
    document.getElementById("education-modal").style.display = "block";
}

// Function to close the Education modal
function closeEducationModal() {
    document.getElementById("education-modal").style.display = "none";
}

// Function to handle form submission for Education
document.getElementById("education-form").onsubmit = function (event) {
    event.preventDefault(); // Prevent default form submission

    // Get the input values
    const degree = document.getElementById("degree").value;
    const institution = document.getElementById("institution").value;
    const startDate = document.getElementById("start-date-education").value;
    const endDate = document.getElementById("end-date-education").value;

    // Create a new education item
    const educationItem = document.createElement("div");
    educationItem.classList.add("education-item");
    educationItem.innerHTML = `
        <div class="degree">${degree}</div>
        <div class="institution">${institution}</div>
        <div class="start-date">${startDate}</div>
        <div class="end-date">${endDate}</div>
        <div class="delete-icon">
            <i class="fas fa-trash" onclick="deleteEducation(this)"></i>
        </div>
    `;

    // Append the new item to the education list
    document.getElementById("education-list").appendChild(educationItem);

    // Clear the form inputs
    document.getElementById("education-form").reset();

    // Close the modal
    closeEducationModal();
};

// Function to delete an education item
function deleteEducation(element) {
    const educationItem = element.parentElement.parentElement;
    educationItem.remove();
}




// Function to open the Skills modal
function openSkillsModal() {
    document.getElementById("skills-modal").style.display = "block";
}

// Function to close the Skills modal
function closeSkillsModal() {
    document.getElementById("skills-modal").style.display = "none";
}

// Function to handle form submission for Skills
document.getElementById("skills-form").onsubmit = function (event) {
    event.preventDefault(); // Prevent default form submission

    // Get the skill name from the input
    const skillName = document.getElementById("skill-name").value;

    // Create a new skill item
    const skillItem = document.createElement("li");
    skillItem.classList.add("skill-item");
    skillItem.textContent = skillName;

    // Append the new item to the skills list
    document.getElementById("skills-list").appendChild(skillItem);

    // Clear the form input
    document.getElementById("skills-form").reset();

    // Close the modal
    closeSkillsModal();
};
let skills = []; // Array to store skills

// Function to handle form submission for Skills
document.getElementById("skills-form").onsubmit = function (event) {
    event.preventDefault(); // Prevent default form submission

    // Get the skill name from the input
    const skillName = document.getElementById("skill-name").value;

    // Add the skill to the array
    skills.push(skillName);

    // Update the skills list
    updateSkillsList();

    // Clear the form input
    document.getElementById("skills-form").reset();

    // Close the modal
    closeSkillsModal();
};

// Function to update the displayed skills list
function updateSkillsList() {
    const skillsList = document.getElementById("skills-list");
    skillsList.innerHTML = ''; // Clear existing list

    // Create list items for each skill
    skills.forEach((skill, index) => {
        const skillItem = document.createElement("li");
        skillItem.innerHTML = `
            ${skill} 
            <i class="fas fa-trash" onclick="removeSkill(${index})" style="color: red; cursor: pointer;"></i>
        `;
        skillsList.appendChild(skillItem);
    });
}

// Function to remove a skill
function removeSkill(index) {
    skills.splice(index, 1); // Remove the skill from the array
    updateSkillsList(); // Update the displayed list
}




// Function to open the certifications modal
function openCertificationsModal() {
    document.getElementById("certifications-modal").style.display = "block";
}

// Function to close the certifications modal
function closeCertificationsModal() {
    document.getElementById("certifications-modal").style.display = "none";
}

// Function to add a certification
function addCertification() {
    const certificationName = document.getElementById("certification").value;
    const issuedBy = document.getElementById("issued-by").value;

    if (certificationName && issuedBy) {
        const certificationsList = document.getElementById("certifications-list");

        // Create a new list item for the certification
        const newCertification = document.createElement("li");
        newCertification.innerHTML = `
            <div>
                <strong>${certificationName}</strong> (Issued by: ${issuedBy})
                <i class="fas fa-trash" onclick="deleteCertification(this)"></i>
            </div>
        `;

        certificationsList.appendChild(newCertification);

        // Clear the input fields
        document.getElementById("certifications-form").reset();

        // Close the modal
        closeCertificationsModal();
    } else {
        alert("Please fill in all fields.");
    }
}

// Function to delete a certification
function deleteCertification(element) {
    const certificationItem = element.parentElement.parentElement;
    certificationItem.remove();
}
document.querySelector('.back-button').addEventListener('click', function () {
    window.location.href = 'Profile.html'; // Redirects to profile page
});






