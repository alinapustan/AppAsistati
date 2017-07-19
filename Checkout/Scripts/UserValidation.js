//variabile globale



function validateCNP() {

    var edValue = document.getElementById("TextBox3");
    var cnp = edValue.value;
    var cnpLength = edValue.value.length;

    var lblValue = document.getElementById("lblCNPValidation");
    document.getElementById("TextBox3").className = document.getElementById("TextBox3").className.replace(" error", ""); // this removes the error class
    if (cnp !== '') { //textbox is not empty
        if (isNumber(cnp)) { //input is number
            if (cnpLength <= 13) {
                PageMethods.CNPValidation(cnp, onSucess, onError);

                function onSucess(result) {
                    lblValue.style.backgroundColor = "orange";
                    lblValue.innerText = result;
                    if (result.length === 0) {
                        lblValue.style.backgroundColor = "white";
                        lblValue.innerText = "Nr. cifre: " + cnpLength;
                        document.getElementById("TextBox3").className = document.getElementById("TextBox3").className.replace(" error", ""); // this removes the error class
                    }
                }
                function onError(result) {
                    //alert('Cannot process your request at the moment');
                    lblValue.innerText = "Eroare dupa functia CNPValidation-js";
                }
            }
            else {
                lblValue.innerText = "CNP-ul introdus are mai mult de 13 caractere!";
                lblValue.style.backgroundColor = "lightblue";
                document.getElementById("TextBox3").className = document.getElementById("TextBox3").className + " error";  // this adds the error class
            }
        }
        else {
            lblValue.innerText = "CNP-ul trebuie sa fie compus din cifre!";
            lblValue.style.backgroundColor = "yellow";
            document.getElementById("TextBox3").className = document.getElementById("TextBox3").className + " error";  // this adds the error class
        }
    }
    else { //textbox is empty don't show anything
        lblValue.innerText = '';
    }
    return false;
}

function isNumber(n) { //check is input is a number
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function hasNumber(myString) {
    return /\d/.test(myString);
}

function validateName() {
    var name = document.getElementById("TextBox1");
    var nameValue = name.value;
    document.getElementById("TextBox1").className = document.getElementById("TextBox1").className.replace(" error", ""); // this removes the error class

    var lblNameValue = document.getElementById("lblNameValidation");
    if (nameValue !== '') { //texbox is not empty
        if (hasNumber(nameValue)) {
            lblNameValue.innerText = "Numele nu trebuie sa contina cifre!";
            document.getElementById("TextBox1").className = document.getElementById("TextBox1").className + " error";  // this adds the error class
        }
        else {
            lblNameValue.innerText = '';
        }
    }
    else { //textbox is empty don't show anything
        lblNameValue.innerText = '';
    }
    return false;
}

function validateSurname() {
    var surname = document.getElementById("TextBox2");
    var surnameValue = surname.value;
    document.getElementById("TextBox2").className = document.getElementById("TextBox2").className.replace(" error", ""); // this removes the error class

    var lblSurnameValue = document.getElementById("lblSurnameValidation");
    if (surnameValue !== '') { //texbox is not empty
        if (hasNumber(surnameValue)) {
            lblSurnameValue.innerText = "Prenumele nu trebuie sa contina cifre!";
            document.getElementById("TextBox2").className = document.getElementById("TextBox2").className + " error";  // this adds the error class
        }
    }
    else { //textbox is empty don't show anything
        lblSurnameValue.innerText = '';
    }
    return false;
}

function saveCheckData() {
    var s = "Probleme: \n";

    var numeElement = document.getElementById("TextBox1");
    var numeValue = numeElement.value;
    var prenumeElement = document.getElementById("TextBox2");
    var prenumeValue = prenumeElement.value;
    var cnpElement = document.getElementById("TextBox3");
    var cnpValue = cnpElement.value;
    var lblCNPValue = document.getElementById("lblCNPValidation");


    if (cnpValue === '' || numeValue === '' || prenumeValue === '') {
        if (cnpValue === '')
            s = s + "Campul CNP e gol!";
        if (numeValue === '')
            s = s + "Campul Nume e gol";
        if (prenumeValue === '')
            s = s + "Campul Prenume e gol";
    }
    else {
        if (lblCNPValue.innerText !== "Nr. cifre: 13")
            s = "CNP-ul introdus nu are 13 cifre!";
    }
    alert(s);
}