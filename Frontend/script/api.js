const API_BASE = 'http://localhost:5000/api/animals';

async function getAnimals() {
    const res = await fetch(API_BASE);
    return await res.json();
}

async function getAnimalById(id) {
    const res = await fetch(`${API_BASE}/${id}`);
    return await res.json();
}

async function getAnimalSound(type) {
    const res = await fetch(`${API_BASE}/sound/${type}`);
    return await res.text();
}

async function createAnimal(animal) {
    const res = await fetch(API_BASE, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(animal)
    });
    return await res.json();
}