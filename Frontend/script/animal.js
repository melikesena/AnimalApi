document.addEventListener("DOMContentLoaded", async () => {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");

    const animal = await getAnimalById(id);
    document.getElementById("name").textContent = animal.name;
    document.getElementById("type").textContent = animal.type;
    document.getElementById("id").textContent = animal.id;

    document.getElementById("soundBtn").addEventListener("click", async () => {
        const sound = await getAnimalSound(animal.type);
        alert (sound);
    });
});
