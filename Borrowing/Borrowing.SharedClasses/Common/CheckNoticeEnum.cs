namespace Borrowing.SharedClasses.Models;

public enum CheckNoticeEnum
{
    ALREADY_BORROWED,
    NOT_FOUND,              // notice doesn't exist
    PENALISED,
    CAN_BORROW,             // available copies exist, go ahead
    CAN_RESERVE,    // no copies, non-reservateur → suggest reservation
    CAN_BORROW_RESERVATEUR, // member is a reservateur and it's their turn (FIFO)
    RESERVED_NOT_READY,     // member is a reservateur but their copy isn't back yet
}