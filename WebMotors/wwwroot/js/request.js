// store id if it's an edit
var editId = null;

const requestMake = async () => {
    const response = await fetch('https://localhost:7086/WebMotorsApi/GetMake');
    const payload = await response.json();

    if (!payload.success)
        alert(payload.message);

    populateDropDown("selectMake", payload);
}

const requestModel = async () => {
    let selectedMake = document.getElementById("selectMake").value.replace(/[^0-9]/g, '');

    if (selectedMake == 0 || selectedMake == undefined)
        return;

    const response = await fetch('https://localhost:7086/WebMotorsApi/GetModel?id=' + selectedMake);
    const payload = await response.json();

    if (!payload.success)
        alert(payload.message);

    populateDropDown("selectModel", payload);
}

const requestVersion = async () => {
    let selectedModel = document.getElementById("selectModel").value.replace(/[^0-9]/g, '');

    if (selectedModel == 0 || selectedModel == undefined)
        return;

    const response = await fetch('https://localhost:7086/WebMotorsApi/GetVersion?id=' + selectedModel);
    const payload = await response.json();

    if (!payload.success)
        alert(payload.message);

    populateDropDown("selectVersion", payload);

}

const fillDataObject = () => {
    let makeDropdown = document.getElementById("selectMake");
    let inputMake = document.getElementById("inputMake");

    inputMake.value = makeDropdown.options[makeDropdown.selectedIndex].text;

    let modelDropdown = document.getElementById("selectModel");
    let inputModel = document.getElementById("inputModel");

    inputModel.value = modelDropdown.options[modelDropdown.selectedIndex].text;

    let versionDropdown = document.getElementById("selectVersion");
    let inputVersion = document.getElementById("inputVersion");

    inputVersion.value = versionDropdown.options[versionDropdown.selectedIndex].text;
}

const populateDropDown = (dropdownId, obj) => {
    let ddl = document.getElementById(dropdownId);

    // clear it first
    ddl.options.length = 1;

    // populate make dropdown
    for (let i = 0; i < obj.data.length; i++) {
        ddl[ddl.length] = new Option(obj.data[i].name, obj.data[i].id);
    }
}

const submit = async () => {
    let payload = {
        "marca": inputMake.value,
        "modelo": inputModel.value,
        "versao": inputVersion.value,
        "quilometragem": inputKM.value,
        "ano": inputAno.value,
        "observacao": textObs.value
    }

    if (editId == null) {
        const response = await fetch('https://localhost:7086/Advertisement', {
            method: 'POST',
            body: JSON.stringify(payload),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const dataResponse = await response.json();

        if (dataResponse.success) {
            populateListAds();
            clearForm();
            alert("Inserido com successo");
        }
        else
            alert(dataResponse.message);

    }
    else {
        payload.id = editId;
        const response = await fetch('https://localhost:7086/Advertisement', {
            method: 'PUT',
            body: JSON.stringify(payload),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const dataResponse = await response.json();

        if (dataResponse.success) {
            populateListAds();
            clearForm();
            editId = null;
            alert("Inserido com successo");
        }
        else
            alert(dataResponse.message);
    }
}

const listAllAds = async () => {
    const response = await fetch('https://localhost:7086/Advertisement');
    return await response.json();
}

const clearTable = () => {
    let table = document.getElementById("listAds");

    while (table.rows.length > 1) {
        table.deleteRow(1);
    }
}

const deleteAdvertisement = async (id) => {
    const response = await fetch('https://localhost:7086/Advertisement/' + id, {
        method: 'DELETE'
    });

    const dataResponse = await response.json();

    if (dataResponse.success) {
        alert("Deletado com sucesso")
        clearTable();
        populateListAds();
    }
    else
        alert(dataResponse.message)
}

const editAdvertisement = async (ad) => {
    inputMake.value = ad.marca;
    inputModel.value = ad.modelo;
    inputVersion.value = ad.versao;
    inputAno.value = ad.ano;
    inputKM.value = ad.quilometragem;
    textObs.value = ad.observacao;

    editId = ad.id;
}

const clearForm = () => {
    inputMake.value = ''
    inputModel.value = ''
    inputVersion.value = ''
    inputKM.value = ''
    inputAno.value = ''
    textObs.value = ''
}

const populateListAds = async () => {
    clearTable()
    let table = document.getElementById('listAds');
    let payload = await listAllAds();

    if (!payload.success) {
        alert(payload.message);
        return;
    }

    for (let i = 0; i < payload.data.length; i++) {
        let ad = payload.data[i];

        let row = document.createElement('tr');
        let properties = ['id', 'marca', 'modelo', 'versao', 'ano', 'quilometragem', 'observacao'];

        for (let j = 0; j < properties.length; ++j) {
            let cell = document.createElement('td');

            cell.innerHTML = ad[properties[j]];

            row.appendChild(cell);
        }

        var btn = document.createElement('button');
        btn.id = ad.id;
        btn.innerHTML = 'Editar';
        btn.onclick = function () {
            editAdvertisement(ad);
        };
        row.appendChild(btn);

        btn = document.createElement('button');
        btn.id = 'Delete' + ad.id;
        btn.innerHTML = 'Deletar';
        btn.onclick = function () {
            deleteAdvertisement(ad.id);
        };

        row.appendChild(btn);
        table.appendChild(row);
    }
}

requestMake();
populateListAds();