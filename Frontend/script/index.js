document.addEventListener("DOMContentLoaded", async () => {
    const animalList = document.getElementById("animalList");
    const animals = await getAnimals();

    animals.forEach(animal => {
        const li = document.createElement("li");
        li.textContent = `${animal.name} (${animal.type})`;
        li.style.cursor = "pointer";
        li.onclick = () => {
            window.location.href = `animal.html?id=${animal.id}`;
        };
        animalList.appendChild(li);
    });

    document.getElementById("addBtn").addEventListener("click", async () => {
        const name = document.getElementById("name").value;
        const type = document.getElementById("type").value;
        if (!name || !type) return alert("Tüm alanları doldurun!");

        const newAnimal = await createAnimal({ name, type });
        alert("Hayvan eklendi!");
        location.reload();
    });
});
