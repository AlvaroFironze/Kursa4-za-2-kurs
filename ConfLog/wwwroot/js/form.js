const func = content.split('!');
function getItems() {

    if (func.includes("Text")) {
        document.getElementById('Text').style.display = 'block';
    }
    if (func.includes('Excel')) {
        document.getElementById('Excel').style.display = 'block';
    }
    if (func.includes('Tcp')) {
        document.getElementById('Tcp').style.display = 'block';
    }
}