<?php

class BookingManager {
    public static function bookRoom($room, $reservation) {
        try {
            $room->addReservation($reservation);
            echo "Room <strong>" . $room->getRoomNumber() . 
            "</strong> succesfully booked for " . $reservation . "</br>";
        } catch (EReservationException $exc) {
            echo "Room <strong>" . $room->getRoomNumber() . 
                    $exc->getMessage() . "</strong></br>";
        }
    }
}
