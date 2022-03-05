class MinHeapTree:
    def __init__(self):
        self.__heap = []

    @staticmethod
    def _parent(index: int) -> int:
        return (index - 1) // 2

    @staticmethod
    def _left(index: int) -> int:
        return index * 2 + 1

    @staticmethod
    def _right(index: int) -> int:
        return index * 2 + 2

    def get_heap(self) -> list:
        return self.__heap

    def display_heap(self):
        print(self.__heap)

    def _min_heapify(self, array: list, index: int, length: int):
        smallest = index
        left = self._left(index)
        right = self._right(index)

        if left <= length - 1 and array[left] < array[index]:
            smallest = left
        if right <= length - 1 and array[right] < array[smallest]:
            smallest = right

        if smallest != index:
            array[smallest], array[index] = array[index], array[smallest]
            self._min_heapify(array, smallest, length)

    def build_min_heap(self, array: list):
        self.__heap = array
        length = len(self.__heap)

        for i in range((length - 1) // 2, -1, -1):
            self._min_heapify(self.__heap, i, length)

    def _build_min_heap(self, array: list):
        length = len(array)

        for i in range((length - 1) // 2, 0, -1):
            self._min_heapify(array, i, length)

    def add(self, num: int):
        self.__heap.append(num)
        pos = len(self.__heap) - 1

        while pos > 0:
            parent = self._parent(pos)
            if self.__heap[pos] < self.__heap[parent]:
                self.__heap[parent], self.__heap[pos] = self.__heap[pos], self.__heap[parent]
                pos = parent
            else:
                break

    def delete(self, index: int):
        length = len(self.__heap)
        self.__heap[index], self.__heap[0] = self.__heap[0], self.__heap[index]
        self.__heap[0], self.__heap[length - 1] = self.__heap[length - 1], self.__heap[0]

        self._min_heapify(self.__heap, 0, length)

    def heap_sort(self, array: list):
        self._build_min_heap(array)
        for i in range(len(array) - 1, 0, -1):
            array[0], array[i] = array[i], array[0]

            self._min_heapify(array, 0, i)


if __name__ == '__main__':
    a = [2, 7, 26, 25, 19, 17, 1, 90, 3, 36]
    tree = MinHeapTree()
    tree.build_min_heap(a)
    tree.display_heap()

    tree.heap_sort(a)
    print(a)
