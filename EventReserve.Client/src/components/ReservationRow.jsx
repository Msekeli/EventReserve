function ReservationRow({ reservation, onEdit, onDelete }) {
  return (
    <tr className="border-t border-slate-200 hover:bg-slate-50/70">
      <td className="border-r border-slate-200 p-4 text-slate-800">
        {reservation.attendeeName}
      </td>

      <td className="border-r border-slate-200 p-4 text-slate-700">
        {reservation.eventName}
      </td>

      <td className="border-r border-slate-200 p-4 text-slate-700">
        {new Date(reservation.eventDate).toLocaleDateString()}
      </td>

      <td className="p-4">
        <div className="flex items-center gap-2">
          <button
            type="button"
            onClick={() => onEdit(reservation)}
            className="cursor-pointer rounded-lg border border-secondary/30 bg-secondary/10 px-3 py-2 text-sm font-medium text-secondary transition hover:bg-secondary/20 active:scale-[0.98]"
          >
            ✏️ Edit
          </button>

          <button
            type="button"
            onClick={() => onDelete(reservation)}
            className="cursor-pointer rounded-lg border border-red-200 bg-red-50 px-3 py-2 text-sm font-medium text-red-600 transition hover:bg-red-100 active:scale-[0.98]"
          >
            🗑 Delete
          </button>
        </div>
      </td>
    </tr>
  );
}

export default ReservationRow;
