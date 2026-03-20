import { useEffect, useState } from "react";
import Header from "../components/Header";
import ReservationTable from "../components/ReservationTable";
import ReservationModal from "../components/ReservationModal";
import ConfirmDialog from "../components/ConfirmDialog";
import ToastMessage from "../components/ToastMessage";
import {
  getReservations,
  createReservation,
  updateReservation,
  deleteReservation,
} from "../services/reservationService";

function ReservationsPage() {
  const [reservations, setReservations] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedReservation, setSelectedReservation] = useState(null);
  const [reservationToDelete, setReservationToDelete] = useState(null);
  const [toast, setToast] = useState(null);

  async function loadReservations() {
    try {
      const data = await getReservations();
      setReservations(data);
    } catch (error) {
      console.error("Failed to load reservations:", error);
    }
  }

  useEffect(() => {
    loadReservations();
  }, []);

  useEffect(() => {
    if (!toast) return;

    const timer = setTimeout(() => {
      setToast(null);
    }, 2500);

    return () => clearTimeout(timer);
  }, [toast]);

  function handleOpenCreateModal() {
    setSelectedReservation(null);
    setIsModalOpen(true);
  }

  function handleEditReservation(reservation) {
    setSelectedReservation(reservation);
    setIsModalOpen(true);
  }

  function handleAskDeleteReservation(reservation) {
    setReservationToDelete(reservation);
  }

  async function handleCreateReservation(formData) {
    try {
      await createReservation(formData);
      await loadReservations();
      setToast({ message: "Reservation added successfully.", type: "success" });
    } catch (error) {
      console.error("Failed to create reservation:", error);
      throw error;
    }
  }

  async function handleUpdateReservation(formData) {
    if (!selectedReservation) return;

    try {
      await updateReservation(selectedReservation.id, formData);
      await loadReservations();
      setToast({
        message: "Reservation updated successfully.",
        type: "success",
      });
    } catch (error) {
      console.error("Failed to update reservation:", error);
      throw error;
    }
  }

  async function handleConfirmDeleteReservation() {
    if (!reservationToDelete) return;

    try {
      await deleteReservation(reservationToDelete.id);
      await loadReservations();
      setToast({
        message: "Reservation deleted successfully.",
        type: "success",
      });
    } catch (error) {
      console.error("Failed to delete reservation:", error);
      setToast({
        message: "Failed to delete reservation.",
        type: "error",
      });
    } finally {
      setReservationToDelete(null);
    }
  }

  function handleCloseModal() {
    setIsModalOpen(false);
    setSelectedReservation(null);
  }

  return (
    <div className="min-h-screen bg-linear-to-br from-slate-50 to-primary/5 p-6">
      <div className="mx-auto max-w-5xl">
        <Header onAdd={handleOpenCreateModal} />

        <ReservationTable
          reservations={reservations}
          onEdit={handleEditReservation}
          onDelete={handleAskDeleteReservation}
        />
      </div>

      {isModalOpen && (
        <ReservationModal
          reservation={selectedReservation}
          onClose={handleCloseModal}
          onSave={
            selectedReservation
              ? handleUpdateReservation
              : handleCreateReservation
          }
        />
      )}

      {reservationToDelete && (
        <ConfirmDialog
          title="Delete Reservation"
          message={`Are you sure you want to delete the reservation for ${reservationToDelete.attendeeName}? This action cannot be undone.`}
          onConfirm={handleConfirmDeleteReservation}
          onCancel={() => setReservationToDelete(null)}
        />
      )}

      {toast && <ToastMessage message={toast.message} type={toast.type} />}
    </div>
  );
}

export default ReservationsPage;
