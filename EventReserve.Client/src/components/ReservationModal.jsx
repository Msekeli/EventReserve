import { useEffect, useState } from "react";

function ReservationModal({ onClose, onSave, reservation }) {
  const [formData, setFormData] = useState({
    attendeeName: "",
    eventName: "",
    eventDate: "",
  });

  const [isSaving, setIsSaving] = useState(false);

  const isEditMode = Boolean(reservation);

  useEffect(() => {
    if (reservation) {
      setFormData({
        attendeeName: reservation.attendeeName || "",
        eventName: reservation.eventName || "",
        eventDate: reservation.eventDate
          ? reservation.eventDate.split("T")[0]
          : "",
      });
    }
  }, [reservation]);

  function handleChange(e) {
    const { name, value } = e.target;

    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  async function handleSubmit(e) {
    e.preventDefault();

    if (
      !formData.attendeeName.trim() ||
      !formData.eventName.trim() ||
      !formData.eventDate
    ) {
      return;
    }

    try {
      setIsSaving(true);
      await onSave(formData);
      onClose();
    } catch (err) {
      console.error("Failed to save:", err);
    } finally {
      setIsSaving(false);
    }
  }

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40 px-4">
      <div className="w-full max-w-md rounded-2xl border border-primary/10 bg-white p-6 shadow-xl">
        <div className="mb-5 flex items-center justify-between">
          <h2 className="text-xl font-semibold text-primary">
            {isEditMode ? "Edit Reservation" : "Add Reservation"}
          </h2>

          <button
            onClick={onClose}
            className="text-slate-500 hover:text-slate-800"
            type="button"
          >
            ✕
          </button>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="mb-1 block text-sm font-medium text-slate-700">
              Attendee Name
            </label>
            <input
              type="text"
              name="attendeeName"
              value={formData.attendeeName}
              onChange={handleChange}
              className="w-full rounded-lg border border-slate-300 px-3 py-2 outline-none focus:border-primary focus:ring-2 focus:ring-primary/20"
              placeholder="Enter name"
            />
          </div>

          <div>
            <label className="mb-1 block text-sm font-medium text-slate-700">
              Event Name
            </label>
            <input
              type="text"
              name="eventName"
              value={formData.eventName}
              onChange={handleChange}
              className="w-full rounded-lg border border-slate-300 px-3 py-2 outline-none focus:border-primary focus:ring-2 focus:ring-primary/20"
              placeholder="Enter event"
            />
          </div>

          <div>
            <label className="mb-1 block text-sm font-medium text-slate-700">
              Event Date
            </label>
            <input
              type="date"
              name="eventDate"
              value={formData.eventDate}
              onChange={handleChange}
              className="w-full rounded-lg border border-slate-300 px-3 py-2 outline-none focus:border-primary focus:ring-2 focus:ring-primary/20"
            />
          </div>

          <div className="flex justify-end gap-3 pt-2">
            <button
              type="button"
              onClick={onClose}
              className="rounded-lg border border-slate-300 px-4 py-2 text-slate-700 hover:bg-slate-100"
            >
              Cancel
            </button>

            <button
              type="submit"
              disabled={isSaving}
              className="rounded-lg bg-primary px-4 py-2 text-white hover:bg-accent disabled:opacity-60"
            >
              {isSaving
                ? isEditMode
                  ? "Updating..."
                  : "Saving..."
                : isEditMode
                  ? "Update"
                  : "Save"}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default ReservationModal;
