<?php

function __autoload($className) {
    include_once("./" . $className . ".class.php");
}

date_default_timezone_set("Europe/Sofia");

$singleRoom1 = new SingleRoom(1408, 99);
$singleRoom2 = new SingleRoom(1420, 58);
$singleRoom3 = new SingleRoom(1425, 75);
$bedRoom1 = new Bedroom(1320, 150);
$bedRoom2 = new Bedroom(1330, 260);
$bedRoom3 = new Bedroom(1340, 250);
$apartament1 = new Apartment(1210, 140);
$apartament2 = new Apartment(1220, 280);
$apartament3 = new Apartment(1230, 249);

$rooms = [$singleRoom1, $singleRoom2, $singleRoom3,
            $bedRoom1, $bedRoom2, $bedRoom3,
            $apartament1, $apartament2, $apartament3];

$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate1 = strtotime("15.02.2015");
$endDate1 = strtotime("20.02.2015");
$reservation1 = new Reservation($startDate1, $endDate1, $guest);
$startDate2 = strtotime("21.02.2015");
$endDate2 = strtotime("23.02.2015");
$reservation2 = new Reservation($startDate2, $endDate2, $guest);
BookingManager::bookRoom($singleRoom1, $reservation1);
BookingManager::bookRoom($singleRoom1, $reservation1);
BookingManager::bookRoom($singleRoom1, $reservation2);
echo '</br>';
$singleRoom1->removeReservation($reservation1);
echo $singleRoom1 . "</br>";

// Filter the array by bedrooms and apartments with a price less or equal to 250.00:
$filteredRooms = array_filter($rooms, function ($room) {
    if (get_class($room) == "Bedroom" || get_class($room) == "Apartment") {
        return $room->getPrice() <= 250;
    }
});

foreach ($filteredRooms as $room) {
    echo get_class($room) . ", price: " . $room->getPrice() . "BGN</br>";
}

// Filter the array by all rooms with a balcony:
$roomsWithBalcony = array_filter($rooms, function ($room) {
    return $room->getHasBalcony() == "has balcony";
});

foreach ($roomsWithBalcony as $room) {
    echo $room . "</br>";
}

// Return the room numbers of all rooms which have a bathtub in their extras:
$roomsWithBathTub = array_filter($rooms, function ($room) {
    return strpos($room->getExtras(),'bathtub') !== false;
});

foreach ($roomsWithBathTub as $room) {
    echo $room->getRoomNumber() . "</br>";
}