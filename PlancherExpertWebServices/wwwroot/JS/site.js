const uri = 'api/CouvrePlanchers';
let couvrePlanchers = [];
function getCP() {
 fetch(uri)
 .then(response => response.json())
 .then(data => _displayItems(data))
 .catch(error => console.error("Impossible d'obtenir les éléments.", error));
};
function addCP() {
    const addType = document.getElementById('Type').value;
    const addPrixMa = document.getElementById('PrixMa').value;
    const addPrixMo = document.getElementById('PrixMo').value;

    const CP = {
        Type: addType.trim(),
        PrixMa: addPrixMa.trim(),
        PrixMo: addPrixMo.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(CP)
    })
    .then(response => response.json())
    .then(() => {
        getCP();
        addType.value = '';
        addPrixMa.value = '';
        addPrixMo.value = '';
    })
    .catch(error => console.error("Impossible d'ajouter l'élément.", error));
};
function deleteCP(id) {
    fetch(`${uri}/${id}`, {
    method: 'DELETE'
    })
    .then(() => getCP())
    .catch(error => console.error('Impossible de supprimer l\'élément.', error));
   };
   function displayEditForm(id) {
    const CP = couvrePlanchers.find(CP => CP.id === id);
    document.getElementById('edit-id').value = CP.id;
    document.getElementById('edit-PrixMa').value = CP.PrixMa;
    document.getElementById('edit-PrixMo').value = CP.PrixMo;
    document.getElementById('edit-Type').value = CP.Type;

    document.getElementById('editForm').style.display = 'block';
}