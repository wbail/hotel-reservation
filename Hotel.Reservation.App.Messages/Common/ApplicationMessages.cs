namespace Hotel.Reservation.App.Messages.Common
{
    public static class ApplicationMessages
    {
        public static string DateError = "The reservation cannot be longer than 3 days and 30 days in advance.";
        public static string ReservationCanceled = "Reservation canceled.";
        public static string ReservationNotFound = "Reservation not found.";
        public static string ApplicationError = "Error in the application";
        public static string ReservationRetrieved = "Reservation retrieved.";
        public static string ReservationUpdated = "Reservation updated with success!";
        public static string RoomIsNotAvailable = "Room is not available.";
        public static string ReservationCompleted = "Reservation completed with success!";
    }
}