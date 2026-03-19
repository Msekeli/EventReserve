const API_BASE_URL = "http://localhost:5007/api/reservations";

async function handleResponse(response) {
  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "API request failed");
  }

  if (response.status === 204) {
    return null;
  }

  return response.json();
}

export async function getReservations() {
  const response = await fetch(API_BASE_URL);
  return handleResponse(response);
}

export async function getReservationById(id) {
  const response = await fetch(`${API_BASE_URL}/${id}`);
  return handleResponse(response);
}

export async function createReservation(reservation) {
  const response = await fetch(API_BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(reservation),
  });

  return handleResponse(response);
}

export async function updateReservation(id, reservation) {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(reservation),
  });

  return handleResponse(response);
}

export async function deleteReservation(id) {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: "DELETE",
  });

  return handleResponse(response);
}
