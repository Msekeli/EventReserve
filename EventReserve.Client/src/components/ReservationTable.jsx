import { useMemo, useState } from "react";
import ReservationRow from "./ReservationRow";

function ReservationTable({ reservations, onEdit, onDelete }) {
  const [showAll, setShowAll] = useState(false);

  const sortedReservations = useMemo(() => {
    return [...reservations].sort(
      (a, b) => new Date(b.eventDate) - new Date(a.eventDate),
    );
  }, [reservations]);

  const visibleReservations = showAll
    ? sortedReservations
    : sortedReservations.slice(0, 6);

  const hasMore = sortedReservations.length > 6;

  return (
    <div className="overflow-hidden rounded-2xl border border-slate-200 bg-white shadow-sm">
      <table className="w-full">
        <thead className="bg-primary/10">
          <tr>
            <th className="border-r border-primary/20 p-4 text-left text-primary">
              Attendee Name
            </th>
            <th className="border-r border-primary/20 p-4 text-left text-primary">
              Event
            </th>
            <th className="border-r border-primary/20 p-4 text-left text-primary">
              Event Date
            </th>
            <th className="p-4 text-left text-primary">Actions</th>
          </tr>
        </thead>

        <tbody>
          {visibleReservations.length === 0 ? (
            <tr>
              <td colSpan="4" className="p-6 text-center text-slate-500">
                No reservations found
              </td>
            </tr>
          ) : (
            visibleReservations.map((reservation) => (
              <ReservationRow
                key={reservation.id}
                reservation={reservation}
                onEdit={onEdit}
                onDelete={onDelete}
              />
            ))
          )}
        </tbody>
      </table>

      {hasMore && (
        <div className="border-t border-slate-200 bg-slate-50 px-4 py-3 text-center">
          <button
            type="button"
            onClick={() => setShowAll((prev) => !prev)}
            className="cursor-pointer text-sm font-medium text-primary hover:underline"
          >
            {showAll ? "Show Less" : "Show More"}
          </button>
        </div>
      )}
    </div>
  );
}

export default ReservationTable;
