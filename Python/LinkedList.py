class Node:
    def __init__(self, content):
        self._next = None
        self._previous = None

        self._content = content

    def set_next(self, next_):
        self._next = next_

    def set_previous(self, previous_):
        self._previous = previous_

    def get_next(self):
        return self._next

    def get_previous(self):
        return self._previous

    def remove_next(self):
        self._next = None

    def remove_previous(self):
        self._previous = None

    def __str__(self):
        return str(self._content)


class LinkedList:
    def __init__(self):
        self._first = None
        self._last = None
        self._length = 0

    def add(self, content):
        node = Node(content)

        if self._last is not None:
            self._last.set_next(node)
            node.set_previous(self._last)
            self._last = node

        elif self._first is not None and self._last is None:
            self._first.set_next(node)
            self._last = node
            self._last.set_previous(self._first)

        elif self._first is None and self._last is None:
            self._first = node

        self._length += 1

    def delete_node(self, index: int):
        current_node = self._first
        next_node = None

        if index > self._length - 1 or index < 0:
            raise IndexError("The index provided is out of the linked list's range")

        if index == 0 and self._length == 1:
            self._first = None
            self._length -= 1
            return

        elif index == 0 and self._length > 1:
            self._first = current_node.get_next()
            current_node.remove_next()
            self._first.remove_previous()
            self._length -= 1
            return

        if index == self._length - 1:
            current_node = self._last
            next_node = current_node.get_previous()
            next_node.remove_next()
            current_node.remove_previous()

            if next_node == self._first:
                self._last = None
            else:
                self._last = next_node

            self._length -= 1
            return

        count = 0
        while count < index:
            count += 1
            next_node = current_node.get_next()
            current_node = next_node

        next_node = current_node.get_next()
        next_node.set_previous(current_node.get_previous())
        current_node.remove_next()
        current_node.remove_previous()
        next_node.get_previous().set_next(next_node)
        self._length -= 1

    def append(self, index: int, content):
        new_node = Node(content)
        current_node = self._first
        next_node = None

        if self._length == 0:
            raise Exception("Linked list is empty, consider adding first to it")

        if index == 0:
            new_node.set_next(self._first)
            self._first.set_previous(new_node)
            self._first = new_node
            self._length += 1
            return

        if index > self._length - 1 and self._last is not None:
            self._last.set_next(new_node)
            new_node.set_previous(self._last)
            self._last = new_node
            self._length += 1
            return

        count = 0
        while count < index:
            count += 1
            next_node = current_node.get_next()
            current_node = next_node

        new_node.set_previous(current_node.get_previous())
        current_node.get_previous().set_next(new_node)
        current_node.set_previous(new_node)
        new_node.set_next(current_node)
        self._length += 1

    def display(self):
        current_node = self._first
        count = 0
        while count < self._length:
            print(current_node, " <-> ", end="")
            current_node = current_node.get_next()
            count += 1
        print("null -- Length: ", self._length)
        print()


if __name__ == '__main__':
    lk = LinkedList()

    lk.add(12)
    lk.add(43)
    lk.add(300)
    lk.add(400)
    lk.add(15)
    lk.add(26)
    lk.add(1000)

    lk.display()

    lk.delete_node(0)
    lk.display()

    lk.delete_node(1)
    lk.display()

    lk.delete_node(2)
    lk.display()

    lk.delete_node(3)
    lk.display()

    lk.append(1, 2156)
    lk.display()
